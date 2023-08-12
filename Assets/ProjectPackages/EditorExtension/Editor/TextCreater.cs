using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class TextCreater
{
    // markdownの作成
    [MenuItem("Assets/Create/Markdown", false, 0)]
    static void CreateMarkdown()
    {
        string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        File.WriteAllText(Path.Combine(selectedPath, "newMarkdown.md"), "");
        AssetDatabase.Refresh();
    }

    // jsonの作成
    [MenuItem("Assets/Create/Json", false, 0)]
    static void CreateJson()
    {
        string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        File.WriteAllText(Path.Combine(selectedPath, "newJson.json"), "");
        AssetDatabase.Refresh();
    }
}
