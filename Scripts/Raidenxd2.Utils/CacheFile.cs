using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CacheFile : MonoBehaviour
{
    public static CacheFile Instance { get; private set; } 
    public string URL = "raidenxd2.github.io/cookieclicker2.mp4/CookieStore.txt";
    public static bool DownloadedFile { get; private set; }

    void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start()
    {
        LoggerSystem.Logger.Log(" ", LoggerSystem.LogTypes.Normal);
        if (Directory.Exists(Application.persistentDataPath + "/Cache") == false)
        {
            LoggerSystem.Logger.Log("Creating Cache directory...", LoggerSystem.LogTypes.Normal);
            Directory.CreateDirectory(Application.persistentDataPath + "/Cache");
        }
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            LoggerSystem.Logger.Log("No internet connection!", LoggerSystem.LogTypes.Error);
            if (!File.Exists(Application.persistentDataPath + "/Cache/CookieStore.txt"))
            {
                LoggerSystem.Logger.Log("No cache file!", LoggerSystem.LogTypes.Error);
                return;
            }
            DownloadedFile = true;
            return;
        }
        LoggerSystem.Logger.Log("Creating new Cache file...", LoggerSystem.LogTypes.Normal);
        File.Delete(Application.persistentDataPath + "/Cache/CookieStore.txt");
        StartCoroutine(GetText(URL));
    }

    IEnumerator GetText(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            AsyncOperation operation = www.SendWebRequest();
            while (!operation.isDone)
            {
                yield return null;
            }
            var data = www.downloadHandler.text;
            LoggerSystem.Logger.Log("Data from server: " + data, LoggerSystem.LogTypes.Normal);
            // File.Create(Application.persistentDataPath + "/Cache/CookieStore.txt");
            File.WriteAllText(Application.persistentDataPath + "/Cache/CookieStore.txt", www.downloadHandler.text);
            DownloadedFile = true;
        }
    }
}
