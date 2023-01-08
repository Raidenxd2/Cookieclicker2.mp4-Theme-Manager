using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System;
using UnityEngine.Rendering;

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
            try
            {
                File.Copy("Packages/raidenxd2.cookieclicker2mp4_theme_manager/Cookieclicker2.mp4/customTheme.unity", "Assets/" + sceneName + ".unity");
            }
            catch (Exception ex)
            {
                EditorUtility.DisplayDialog("Error!", "An error occured while creating a new Scene: " + ex, "OK", "");
                return;
            }
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
        if (GUILayout.Button("Create mod.json"))
        {
            ModJSONCreator.ShowWindow();
        }
        if (GUILayout.Button("Build AssetBundle for Windows"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to build the AssetBundle?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Windows)");
            }
        }
        if (GUILayout.Button("Build AssetBundle for Mac"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to build the AssetBundle?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Mac)");
            }
        }
        if (GUILayout.Button("Build AssetBundle for Linux"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to build the AssetBundle?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Linux)");
            }
        }
        if (GUILayout.Button("Build AssetBundle for Android"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to build the AssetBundle?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Android)");
            }
        }
        if (GUILayout.Button("Build AssetBundle for all"))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to build the AssetBundle?", "Yes", "No"))
            {
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Android)");
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Linux)");
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Mac)");
                EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Windows)");
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
        if (GUILayout.Button("Setup Project Render API Settings..."))
        {
            if (EditorUtility.DisplayDialog("Question", "Are you sure you want to setup the project Render API? This may require a restart of Unity.", "Yes", "No"))
            {
                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 0);
                PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android, false);

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 10);
                PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneWindows, false);

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 20);
                PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneOSX, false);

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 30);
                PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.StandaloneLinux64, false);

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 40);
                PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new [] { GraphicsDeviceType.Vulkan, GraphicsDeviceType.OpenGLES3, GraphicsDeviceType.OpenGLES2 });

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 50);
                PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneLinux64, new [] { GraphicsDeviceType.OpenGLCore, GraphicsDeviceType.Vulkan });

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 60);
                PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneOSX, new [] { GraphicsDeviceType.Metal, GraphicsDeviceType.OpenGLCore });

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 70);
                PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows, new [] { GraphicsDeviceType.Vulkan, GraphicsDeviceType.Direct3D12, GraphicsDeviceType.Direct3D11, GraphicsDeviceType.OpenGLCore });

                EditorUtility.DisplayProgressBar("Cookieclicker2.mp4 Theme Manager", "Setting Graphics APIs...", 80);
                EditorUtility.ClearProgressBar();
            }
        }
        if (GUILayout.Button("Asset Bundle Browser"))
        {
            EditorApplication.ExecuteMenuItem("Window/AssetBundle Browser");
        }
        if (File.Exists("Assets/EasyQuestSwitch/EQS_Data.cs"))
        {
            if (GUILayout.Button("Easy Quest Switch"))
            {
                EditorApplication.ExecuteMenuItem("Window/Easy Quest Switch");
            }
        }
    }
}
