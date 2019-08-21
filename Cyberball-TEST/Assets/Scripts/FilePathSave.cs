//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System.IO;
//using UnityEngine.UI;

//public class FilePathSave : MonoBehaviour
//{
//    public Button FileBrowser;

//    private void Start()
//    {
//        FileBrowser.onClick.AddListener(TaskOnClick);
//    }

//    void TaskOnClick()
//    {
//        Object[] textures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Unfiltered);
//        if (textures.Length == 0)
//        {
//            EditorUtility.DisplayDialog("Select FilePath", "You must have a filepath first first!", "OK");
//            return;
//        }

//        string path = EditorUtility.SaveFolderPanel("Save config file to folder", "", "");
//        if (path.Length != 0)
//        {
//            foreach (Texture2D texture in textures)
//            {
//                Texture2D processedTex = texture;

//                byte[] pngData = processedTex.EncodeToPNG();
//                if (pngData != null)
//                    File.WriteAllBytes(path + "/" + texture.name + ".png", pngData);
//                else
//                    Debug.Log("Could not convert " + texture.name + " to png. Skipping saving texture.");
//            }
//            // Just in case we are saving to the asset folder, tell Unity to scan for modified or new assets
//            AssetDatabase.Refresh();
//        }
//    }
//}