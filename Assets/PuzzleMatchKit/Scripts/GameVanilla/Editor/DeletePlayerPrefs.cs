﻿// Copyright (C) 2017-2020 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using UnityEditor;
using UnityEngine;

namespace GameVanilla.Editor
{
    /// <summary>
    /// Utility class for deleting the PlayerPrefs from within the editor.
    /// </summary>
    public class DeletePlayerPrefs
    {
        [MenuItem("Tools/Puzzle Match Kit/Delete PlayerPrefs", false, 1)]
        public static void DeleteAllPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
