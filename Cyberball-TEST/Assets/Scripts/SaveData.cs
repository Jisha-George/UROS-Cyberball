using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

    string filename = "settings.json";
    string path;

    GameData gameData = new GameData();

	// Use this for initialization
	void Start () {
        path = Application.persistentDataPath + "/" + filename;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void saveData()
    {
        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void readData()
    {

    }
}
