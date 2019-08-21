using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
    
    public void PlayB()
    {
        //load play
        SceneManager.LoadScene("Play");
    }    

    public void SettingsB()
    {
        //load settings
        SceneManager.LoadScene("Settings");
    }



    public void BackB()
    {

    }

    public void StartB()
    {
        SceneManager.LoadScene("Child");
    }

    public void QuitB()
    {
        //quit
        Debug.Log("Quit!");
        Application.Quit();
    }
}
