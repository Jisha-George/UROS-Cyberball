using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONWriter : MonoBehaviour {

    string filename = "data.json";
    string path;

    //Data data = new Data();
    GameData gameData = new GameData();

    // Use this for initialization
    void Start () {
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
	}
	
	// Update is called once per frame
	void Update () {
		//gameData.GetData();
    }

    //public void SaveData()
    //{
        
    //    data.Age = gameData.AgeS;
    //    data.Gen = gameData.GenS;
    //    data.GM = gameData.GMS;
    //    data.R = gameData.RS;
    //    data.P = gameData.PS;
    //    string content = JsonUtility.ToJson(data, true);
    //    System.IO.File.WriteAllText(path, content);
    //}
}