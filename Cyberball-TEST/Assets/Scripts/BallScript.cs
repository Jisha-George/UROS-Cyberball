using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject BallHandL;
    public GameObject parentbone;
    public GameObject Ball;
    public GameObject HandL;
    public GameObject HandR;
    public GameObject AJR;
    public GameObject AJL;

    static Animator anim;

    // Use this for initialization
    void Start ()
    {
        BallHandL.transform.parent = parentbone.transform;
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Rel()
    {
        anim.SetTrigger("Throwing");
        Ball.transform.parent = null;
        BallHandL.SetActive(false);
        Ball.SetActive(true);
        Debug.Log("poof");
    }

    public void RelPlayer()
    {
        Ball.transform.parent = null;
        BallHandL.SetActive(false);
        Ball.SetActive(true);
        anim.SetTrigger("T2P");
        Debug.Log("PlayerCatch!");
    }

    public void playercatch()
    {
        Hand HandScript = (Hand)HandL.GetComponent("Hand");
        HandScript.CatchBall();
        HandRight HandRight = (HandRight)HandR.GetComponent("HandRight");
        HandRight.CatchBall();
    }

    public void rightcatch()
    {
        Thrower RightScript = (Thrower)AJR.GetComponent("Thrower");
        RightScript.RightPlayerCatch();
    }

    public void leftcatch()
    {
        Player LeftScript = (Player)AJL.GetComponent("Player");
        LeftScript.LeftPlayerCatch();
    }
}