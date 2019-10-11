using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
