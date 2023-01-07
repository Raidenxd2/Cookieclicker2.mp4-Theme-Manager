using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class GetTextFromServer : MonoBehaviour
{

    public string URL;
    public int Item;
    public TMP_Text Text;
    public string ErrorText = "Uh oh, something went wrong while downloading the file. Please try again later. Error details: ";

    // Start is called before the first frame update
    void Start()
    {
        if (CacheFile.DownloadedFile)
        {
            var data = File.ReadAllText(Application.persistentDataPath + "/Cache/CookieStore.txt");
            LoggerSystem.Logger.Log(data, LoggerSystem.LogTypes.Normal);
            var dataSplit = data.Split(",");
            Text.text = dataSplit[Item];
        }
        else
        {
            // StartCoroutine(GetText(URL));
        }
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
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Text.SetText(ErrorText + www.error);
                yield break;
                //UnityEngine.Debug.LogError(www.error);
            }
            if (www.responseCode == 404)
            {
                Text.SetText(ErrorText + www.error);
                yield break;
            }
            if (www.responseCode == 500)
            {
                Text.SetText(ErrorText + www.error);
                yield break;
            }
            if (www.responseCode == 403)
            {
                Text.SetText(ErrorText + www.error);
                yield break;
            }
            else
            {
                var data = www.downloadHandler.text;
                LoggerSystem.Logger.Log("Data from server: " + data, LoggerSystem.LogTypes.Normal);
                var dataSplit = data.Split(",");
                Text.text = dataSplit[Item];
            }
        }
    }
}
