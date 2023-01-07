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

    [MenuItem("Cookieclicker2.mp4 Theme Manager/Build AssetBundle")]
    static void BuildAssetBundle()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            AssetDatabase.Refresh();
            File.Delete("Assets/AssetBundles/customTheme.assets");
            File.Move("Assets/AssetBundles/customTheme", "Assets/AssetBundles/customTheme.assets");
            Debug.Log("Built Theme");
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured while building theme:\n" + e.ToString());
        }
    }
}
