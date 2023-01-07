using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.IO;

public class ModJSONCreator : EditorWindow
{
    
    public string modName;
    public string modVersion;
    public string modType = "Theme";
    public string themeName;
    public string customSkyEnabled;
    public string customSkyMatName;
    public string android_support;
    public string windows_support;
    public string mac_support;
    public string linux_support;

    [SerializeField] private ThemeModJSON TMJ = new ThemeModJSON();

    public static void ShowWindow()
    {
        ModJSONCreator MJSONC = (ModJSONCreator)GetWindow(typeof(ModJSONCreator), false, "mod.json Creator");
        MJSONC.minSize = new Vector2(500, 200);
        MJSONC.maxSize = new Vector2(500, 200);
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Mod Name");
        modName = GUILayout.TextField(modName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Mod Version");
        modVersion = GUILayout.TextField(modVersion);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Theme Name");
        themeName = GUILayout.TextField(themeName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Custom Sky Enabled (true/false)");
        customSkyEnabled = GUILayout.TextField(customSkyEnabled);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Custom Sky Material Name");
        customSkyMatName = GUILayout.TextField(customSkyMatName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Android Support (true/false)");
        android_support = GUILayout.TextField(android_support);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Windows Support (true/false)");
        windows_support = GUILayout.TextField(windows_support);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Mac Support (true/false)");
        mac_support = GUILayout.TextField(mac_support);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Linux Support (true/false)");
        linux_support = GUILayout.TextField(linux_support);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Create"))
        {
            if (EditorUtility.DisplayDialog("Creating mod.json", "Are you sure you want to create a new mod.json file? It will be located in Assets/" + modName + "/mod.json", "Yes", "No"))
            {
                TMJ.mod_name = modName;
                TMJ.mod_version = modVersion;
                TMJ.mod_type = "Theme";
                TMJ.theme_name = themeName;
                TMJ.theme_customsky_enabled = customSkyEnabled;
                TMJ.theme_customsky_name = customSkyMatName;
                TMJ.android_support = android_support;
                TMJ.windows_support = windows_support;
                TMJ.mac_support = mac_support;
                TMJ.linux_support = linux_support;
                if (!Directory.Exists("Assets/" + modName))
                {
                    Directory.CreateDirectory("Assets/" + modName);
                    AssetDatabase.Refresh();
                }
                if (File.Exists("Assets/" + modName + "/mod.json"))
                {
                    if (EditorUtility.DisplayDialog("File already exists!", "A mod.json file already exists. If you continue the mod.json file will be deleted. Do you want to continue?", "Yes", "No"))
                    {
                        File.Delete("Assets/" + modName + "/mod.json");
                        AssetDatabase.Refresh();
                    }
                    else
                    {
                        return;
                    }
                }
                string json = JsonUtility.ToJson(TMJ);
                File.WriteAllText("Assets/" + modName + "/mod.json", json);
                AssetDatabase.Refresh();
                EditorUtility.DisplayDialog("Created mod.json", "Created mod.json", "OK", "");
            }
        }
        if (GUILayout.Button("Load"))
        {
            if (EditorUtility.DisplayDialog("", "Not Implemented Yet!", "OK", ""))
            {

            }
        }
        GUILayout.EndHorizontal();
    }
}

[System.Serializable]
public class ThemeModJSON
{
    public string mod_name;
    public string mod_version;
    public string mod_type;
    public string theme_name;
    public string theme_customsky_enabled;
    public string theme_customsky_name;
    public string android_support;
    public string windows_support;
    public string mac_support;
    public string linux_support;
}