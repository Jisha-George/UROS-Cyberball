//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System.IO;
//using UnityEngine.UI;

//public class FilePathOpen : MonoBehaviour
//{
//    public Button FileBrowser;

//    private void Start()
//    {
//        FileBrowser.onClick.AddListener(TaskOnClick);
//    }

//    void TaskOnClick()
//    {
//        string path = EditorUtility.OpenFolderPanel("Select Folder", "", "");
//        string[] files = Directory.GetFiles(path);
//    }
//}
