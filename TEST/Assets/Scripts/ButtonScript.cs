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
        SceneManager.LoadScene("Settings");
    }

}
