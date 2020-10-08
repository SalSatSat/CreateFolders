// Copyright (c) 2020 Muhammad Salihin Bin Zaol-kefli
// All rights reserved.
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
// Author:  Muhammad Salihin Bin Zaol-kefli  (salsatsat@gmail.com)
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateModuleFolder : ScriptableWizard
{
    [Header("Folder Essentials")]
    public string moduleFolderName = "New Module Folder";
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
        // Create primary folder
        string guid = AssetDatabase.CreateFolder("Assets", moduleFolderName);
        string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        // Create all the subfolders required in a module
        foreach (string subfolder in subfolders)
        {
            string subGuid = AssetDatabase.CreateFolder(newFolderPath, subfolder);
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

    [MenuItem("Assets/Create/Module Folder", false, 20)]
    private static void CreateWizard()
    {
        DisplayWizard("Module Folder", typeof(CreateModuleFolder), "Create");
    }
}

