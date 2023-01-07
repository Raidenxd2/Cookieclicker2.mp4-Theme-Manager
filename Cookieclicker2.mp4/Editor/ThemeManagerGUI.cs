using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;

public class ThemeManagerGUI : EditorWindow
{

    public int tabs = 3;
    string[] tabOptions = new string[] {"Create", "Build", "Other"};

    public string sceneName;

    [MenuItem("Cookieclicker2.mp4 Theme Manager/Theme Manager...")]
    public static void ShowWindow()
    {
        ThemeManagerGUI TMGUI = (ThemeManagerGUI)GetWindow(typeof(ThemeManagerGUI), false, "Theme Manager");
        TMGUI.minSize = new Vector2(300, 200);
        TMGUI.maxSize = new Vector2(300, 200);
    }


    void OnGUI()
    {
        tabs = GUILayout.Toolbar(tabs, tabOptions);
        switch (tabs)
        {
            case 0:
                CreateTab();
                break;
            case 1:
                BuildTab();
                break;
            case 2:
                OtherTab();
                break;
        }
    }

    void CreateTab()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Scene Name");
        sceneName = GUILayout.TextField(sceneName);
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Create new Scene"))
        {
            // SceneTemplateService.Instantiate(new SceneTemplateAsset(), false, EditorUtility.OpenFilePanel("Save Scene file...", "", ".unity"));
            File.Copy("Packages/cookieclicker2mp4_theme_manager/Cookieclicker2.mp4/customTheme.unity", "Assets/" + sceneName + ".unity");
            AssetDatabase.Refresh();
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene("Assets/" + sceneName + ".unity");
            }
            else
            {
                // LoggerSystem.Logger.Log("User canceled the save scene request.", LoggerSystem.LogTypes.Error);
            }
            
        }
    }

    void BuildTab()
    {
        if (GUILayout.Button("Build AssetBundle"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to build the AssetBundle?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle");
            }
        }
        if (GUILayout.Button("Bake Prefab Lightmaps"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to Bake Prefab Lightmaps?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Bake Prefab lightmap data");
            }
        }
    }
    
    void OtherTab()
    {
        if (GUILayout.Button("Asset Bundle Browser"))
        {
            EditorApplication.ExecuteMenuItem("Window/AssetBundle Browser");
        }
    }
}
