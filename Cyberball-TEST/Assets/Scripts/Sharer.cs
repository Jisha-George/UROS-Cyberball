using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharer : MonoBehaviour {

    public int throws;
    public GameObject popUp;
    public GameObject AJL;
    public GameObject AJR;
    public GameObject PL;
    public GameObject PR;

    public JSONData set;

    public string VER, AER, DER;

    public void Start()
    {
        string path = "C:/Users/computing/AppData/LocalLow/UROS/Cyberball-TEST/data.json";
        set = new JSONData(path);

        if (set.Gender == "Only Girls")
        {
            PR.SetActive(true);
            PL.SetActive(true);
            AJL.SetActive(false);
            AJR.SetActive(false);
        }
        else if (set.Gender == "Only Boys")
        {
            AJR.SetActive(true);
            AJL.SetActive(true);
            PL.SetActive(false);
            PR.SetActive(false);
        }
        else
        {
            AJR.SetActive(true);
            AJL.SetActive(false);
            PL.SetActive(true);
            PR.SetActive(false);
        }
    }
    

}
