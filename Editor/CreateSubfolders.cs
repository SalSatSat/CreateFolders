// Copyright (c) 2020 Muhammad Salihin Bin Zaol-kefli
// All rights reserved.
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
// Author:  Muhammad Salihin Bin Zaol-kefli  (salsatsat@gmail.com)
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateSubfolders : ScriptableWizard
{
    [Header("Folder Essentials")]
    public List<string> subfolders = new List<string>() { "Scenes", "Scripts", "Materials", "Prefabs", "Textures" };

    //
    // Unity Methods
    //

    private void Awake()
    {
        // Sort list of subfolders in ascending order
        subfolders.Sort();
    }

    //
    // Event Methods
    //

    // Create button click
    private void OnWizardCreate()
    {
        // Get currently selected folder
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (string.IsNullOrEmpty(path))
        {
            path = "Assets";
        }
        else if (!string.IsNullOrEmpty(Path.GetExtension(path)))
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        // Create all the subfolders at currently selected path
        foreach (string subfolder in subfolders)
        {
            string subGuid = AssetDatabase.CreateFolder(path, subfolder);
            string newSubFolderPath = AssetDatabase.GUIDToAssetPath(subGuid);
        }

        AssetDatabase.Refresh();
    }

    //
    // Public Methods
    //


    //
    // Private Methods
    //

    [MenuItem("Assets/Create/Subfolders", false, 30)]
    private static void CreateWizard()
    {
        DisplayWizard("Subfolders", typeof(CreateSubfolders), "Create");
    }
}

