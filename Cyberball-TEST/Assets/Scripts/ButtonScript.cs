using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonScript : MonoBehaviour {

    public GameObject popup;
    public JSONData set;

    void Start()
    {

    }
    public void PlayB()
    {
        
        SceneManager.LoadScene("Settings");
    }    

    public void SettingsB()
    {
        //load settings
        
    }

    public void BackB()
    {
        SceneManager.LoadScene("Welcome Screen");
    }

    public void StartB()
    {
        SceneManager.LoadScene("Loading");
    }

    public void FinB()
    {
        popup.SetActive(false);
        SceneManager.LoadScene("Loading");
    }

    public void QuitB()
    {
        //quit
        //Debug.Log("Quit!");
        string path = "C:/Users/computing/AppData/LocalLow/UROS/Cyberball-TEST/data.json";
        set = new JSONData(path);
        new DataSaver(set.GameMode, set.Age, set.Gender, set.Rounds.ToString(), "", "");
        Application.Quit();
    }

    public void V1()
    {

    }

    public void V2()
    {

    }
    public void V3()
    {

    }
    public void V4()
    {

    }
    public void V5()
    {

    }

    public void A1()
    {

    }

    public void A2()
    {

    }
    public void A3()
    {

    }
    public void A4()
    {

    }
    public void A5()
    {

    }

    public void D1()
    {

    }

    public void D2()
    {

    }
    public void D3()
    {

    }
    public void D4()
    {

    }
    public void D5()
    {

    }
}
