﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JSONWriter : MonoBehaviour {

   // public InputField PlayerName;
    public Dropdown GMD;
    public Dropdown AgeDrop;
    public Dropdown GenderDrop;
    public InputField RoundNum;
    
    public int DropdownValA, DropdownValG, DropdownValGM;

    string filename = "data.json";
    string path;
   
    // Use this for initialization
    void Start()
    {
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
        //C:\Users\Student\AppData\LocalLow\UROS\JSON_TEST
    }

    public void SaveData()
    {
        SaveObject saveObject = new SaveObject
        {
           // Player = PlayerName.text.ToString(),
            GameMode = GMD.options[DropdownValGM].text.ToString(),
            Age = AgeDrop.options[DropdownValA].text.ToString(),
            Gender = GenderDrop.options[DropdownValG].text.ToString(),
            Rounds = RoundNum.text.ToString(),
        };

        string content = JsonUtility.ToJson(saveObject, true);
        System.IO.File.WriteAllText(path, content);

    }
    private class SaveObject
    {
        public string GameMode, Age, Gender, Rounds;
    }

    void Update()
    {   
        DropdownValA = AgeDrop.value;
        DropdownValG = GenderDrop.value;
        DropdownValGM = GMD.value;

        if (Input.GetKeyDown(KeyCode.End))
        {
            Debug.Log("AgeDrop: " + AgeDrop.options[DropdownValA].text);
            Debug.Log("GenderDrop: " + GenderDrop.options[DropdownValG].text);
            Debug.Log("Gamemode: " + GMD.options[DropdownValGM].text);
        }
    }

    public void GetRounds(string rounds)
    {
        Debug.Log("RoundNum: " + rounds);
    }

    public void GetPlayer(string player)
    {
       Debug.Log("Name: " + player);
    }

    public void back()
    {
        SceneManager.LoadScene("Tester");
    }
}