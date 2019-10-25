using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonScript : MonoBehaviour {

    public GameObject popup;
    public GameObject Ball;
    public JSONData set;
    public GameObject menu;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Thank You")
        {
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        menu.SetActive(true);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Thank You" && Input.GetKeyDown("escape"))
        {
            BackB();
        }
    }
    public void PlayB()
    {
        SceneManager.LoadScene("Settings");
    }    

    public void SettingsB()
    {
        //load settings
        SceneManager.LoadScene("Welcome Screen");
        
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
        string path = "data.json";
        set = new JSONData(path);
        Sharer share = Ball.GetComponent<Sharer>();
        new DataSaver(set.GameMode, set.Age, set.Gender, set.Rounds.ToString(), share.counter.ToString(), VALENCE, AROUSAL, DOMINANCE);
        
    }

    public void QuitB()
    {
        //quit
        Application.Quit();
        //Debug.Log("Quit!");
    }
 
    public string VALENCE;
    public string AROUSAL;
    public string DOMINANCE;

    public void selectMe(Button button) {
        string name = button.name;
        string parentName = button.transform.parent.name;

        //Debug.Log("parentName(" + parentName + ") name(" + name + ")");

        if (parentName=="VALENCE")
            VALENCE = name;

        if (parentName=="AROUSAL")
            AROUSAL = name;

        if (parentName=="DOMINANCE")
            DOMINANCE = name;

        foreach (Transform child in button.transform.parent.transform)
        {
            if (child.name == name)//Button Not Clicked
                child.GetComponent<Image>().color = new Color32(0, 255, 255, 100);
            else //Button Clicked
                child.GetComponent<Image>().color = new Color32(255, 0, 0, 0);

        }
    }
}
