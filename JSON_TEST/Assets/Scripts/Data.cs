using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//[System.Serializable]
public class Data : MonoBehaviour
{

    //    GameData gameData = new GameData();
    //    public string Age, Gen, GM, R, P;

    public Text stuff;
    public Text blank;
    public JSONData t;

    void Start()
    {


        string path = "C:/Users/computing/AppData/LocalLow/UROS/JSON_TEST/data.json";
        string filePath = Path.Combine(Application.streamingAssetsPath, path);
        if (File.Exists(filePath))
        {
            //if file exist
        }
        else
        {
            //if file not exist
        }



        t = new JSONData("C:/Users/computing/AppData/LocalLow/UROS/JSON_TEST/data.json");
        stuff.text = t.Age + " " + t.GameMode + " " + t.Gender + " " + t.Rounds;


        if(t.GameMode == "Inclusive")
        {
            blank.text = "hi";
        }
        else
        {
            blank.text = "bye";
        }
    }   

}
