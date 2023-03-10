using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public class Cookieclicker2mp4ThemeManager
{
    // [MenuItem("Cookieclicker2.mp4 Theme Manager/Create Theme")]
    // static void BuildAllAssetBundles()
    // {
    //     Debug.Log("Building lightmaps...");
    //     EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Bake Prefab lightmap data");
    //     EditorApplication.ExecuteMenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle");
    // }

    [MenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Windows)")]
    static void BuildAssetBundleWindows()
    {
        string assetBundleDirectory = "Assets/AssetBundles/Windows";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
            File.Delete("Assets/AssetBundles/Windows/customTheme.assets");
            File.Delete("Assets/AssetBundles/Windows/customTheme_Windows.assets");
            File.Move("Assets/AssetBundles/Windows/customTheme", "Assets/AssetBundles/Windows/customTheme_Windows.assets");
            AssetDatabase.Refresh();
            Debug.Log("Built Theme");
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured while building theme:\n" + e.ToString());
        }
    }
    [MenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Mac)")]
    static void BuildAssetBundleMac()
    {
        string assetBundleDirectory = "Assets/AssetBundles/Mac";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
            File.Delete("Assets/AssetBundles/Mac/customTheme.assets");
            File.Delete("Assets/AssetBundles/Mac/customTheme_Mac.assets");
            File.Move("Assets/AssetBundles/Mac/customTheme", "Assets/AssetBundles/Mac/customTheme_Mac.assets");
            AssetDatabase.Refresh();
            Debug.Log("Built Theme");
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured while building theme:\n" + e.ToString());
        }
    }
    [MenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Linux)")]
    static void BuildAssetBundleLinux()
    {
        string assetBundleDirectory = "Assets/AssetBundles/Linux";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneLinux64);
            File.Delete("Assets/AssetBundles/Linux/customTheme.assets");
            File.Delete("Assets/AssetBundles/Linux/customTheme_Linux.assets");
            File.Move("Assets/AssetBundles/Linux/customTheme", "Assets/AssetBundles/Linux/customTheme_Linux.assets");
            AssetDatabase.Refresh();
            Debug.Log("Built Theme");
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured while building theme:\n" + e.ToString());
        }
    }
    [MenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle (Android)")]
    static void BuildAssetBundleAndroid()
    {
        string assetBundleDirectory = "Assets/AssetBundles/Android";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
            File.Delete("Assets/AssetBundles/Android/customTheme.assets");
            File.Delete("Assets/AssetBundles/Android/customTheme_Android.assets");
            File.Move("Assets/AssetBundles/Android/customTheme", "Assets/AssetBundles/Android/customTheme_Android.assets");
            AssetDatabase.Refresh();
            Debug.Log("Built Theme");
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured while building theme:\n" + e.ToString());
        }
    }
}
