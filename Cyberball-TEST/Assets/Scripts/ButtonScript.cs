using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonScript : MonoBehaviour {

    public GameObject popup;

    void Start()
    {

    }
    public void PlayB()
    {
        string path = "C:/Users/computing/AppData/LocalLow/UROS/Cyberball-TEST/data.json";
        string filePath = Path.Combine(Application.streamingAssetsPath, path);

        if (File.Exists(filePath))
        {
            //if file exist
            //load play
            SceneManager.LoadScene("Play");
        }
        else
        {
            //if file not exist
            popup.SetActive(true);
        }
    }    

    public void SettingsB()
    {
        //load settings
        SceneManager.LoadScene("Settings");
    }

    public void BackB()
    {
        SceneManager.LoadScene("Welcome Screen");
    }

    public void StartB()
    {
        SceneManager.LoadScene("Loading");
    }

    public void QuitB()
    {
        //quit
        //Debug.Log("Quit!");
        Application.Quit();
    }
}
