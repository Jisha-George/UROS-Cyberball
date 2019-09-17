using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

    public Dropdown Age;
    public Dropdown Gender;
    public Dropdown GameMode;
    public InputField Rounds;
    public InputField Player;

    public int DropdownValA, DropdownValG, DropdownValGM;
    public string AgeS, GenS, GMS, RS, PS;



    string filename = "data.json";
    string path;

   // Data data = new Data();
    GameData gameData = new GameData();

    // Use this for initialization
    void Start()
    {
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
    }

    public void SaveData()
    {
        AgeS = Age.options[DropdownValA].text.ToString();
        GenS = Gender.options[DropdownValG].text.ToString();
        GMS = GameMode.options[DropdownValGM].text.ToString();
        RS = Rounds.text.ToString();
        PS = Player.text.ToString();
        string content = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(path, content);
    }





    void Update()
    {   
        DropdownValA = Age.value;
        DropdownValG = Gender.value;
        DropdownValGM = GameMode.value;

        if (Input.GetKeyDown(KeyCode.End))
        {
            Debug.Log("Age: " + Age.options[DropdownValA].text);
            Debug.Log("Gender: " + Gender.options[DropdownValG].text);
            Debug.Log("Gamemode: " + GameMode.options[DropdownValGM].text);
        }

       // GetData();
    }

    public void GetRounds(string rounds)
    {
        Debug.Log("Rounds: " + rounds);
    }

    public void GetPlayer(string player)
    {
        Debug.Log("Name: " + player);
    }

    public void GetData()
    {
        AgeS = Age.options[DropdownValA].text.ToString();
        GenS = Gender.options[DropdownValG].text.ToString();
        GMS = GameMode.options[DropdownValGM].text.ToString();
        RS = Rounds.text.ToString();
        PS = Player.text.ToString();
    }
}