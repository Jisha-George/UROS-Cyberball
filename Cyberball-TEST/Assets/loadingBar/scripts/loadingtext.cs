using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loadingtext : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed;
    public JSONData set;
    public Text text;
    public Text textNormal;

    int rand;

    // Use this for initialization
    void Start () {
        string path = "C:/Users/computing/AppData/LocalLow/UROS/Cyberball-TEST/data.json";
        set = new JSONData(path);

        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;

        if (rand == 2)
        {
            speed = 100;
        }
        else if (rand == 3)
        {
            speed = 50;
        }
        else
        {
            speed = 25;
        }
    }
	
	// Update is called once per frame
	void Update () {
        int a = 0;
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            a = (int)(imageComp.fillAmount * 100);
            if (a > 0 && a <= 75)
            {
                textNormal.text = "Loading...";
            }
            else if (a > 75 && a <= 99)
            {
                textNormal.text = "Please wait...";
            }
            else {

            }
            text.text = a + "%";
        }
        else
        {
            imageComp.fillAmount = 0.0f;
            text.text = "0%";
        }

        if(a == 100)
        {
            if (set.Age == "Child")
            {
                SceneManager.LoadScene("Child");
            }
            else
            {
                SceneManager.LoadScene("Teen");
            }
        }
    }

    public void randGen()
    {
        rand = Random.Range(2, 5);
    }

}
