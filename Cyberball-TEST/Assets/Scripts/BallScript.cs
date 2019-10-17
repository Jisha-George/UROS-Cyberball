using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject BallHandL;
    public GameObject BallHandR;
    public GameObject Ball;
    public GameObject HandL;
    public GameObject HandR;
    public GameObject AJR;
    public GameObject AJL;
    public GameObject PL;
    public GameObject PR;

    static Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Rel()
    {
        BallHandL.SetActive(false);
        Ball.SetActive(true);
        //Ball.transform.parent = null;
        anim.SetTrigger("isThrowing");
        //Debug.Log("poof");
    }

    public void RelPlayer()
    {
        BallHandL.SetActive(false);
        Ball.SetActive(true);
        //Ball.transform.parent = null;
        anim.SetTrigger("T2P");
        //Debug.Log("PlayerCatch!");
    }

    public void RelL()
    {
        BallHandR.SetActive(false);
        Ball.SetActive(true);
       // Ball.transform.parent = null;
        anim.SetTrigger("Throw");
        //Debug.Log("Right");
    }

    public void RelPlayerL()
    {
        BallHandR.SetActive(false);
        Ball.SetActive(true);
       // Ball.transform.parent = null;
        anim.SetTrigger("L2P");
        //Debug.Log("PlayerCatch!");
    }

    public void playercatch()
    {
        Hand HandScript = (Hand)HandL.GetComponent("Hand");
        HandScript.CatchBall();
        HandRight HandRight = (HandRight)HandR.GetComponent("HandRight");
        HandRight.CatchBall();
    }

    public void playercatchL()
    {
        Hand HandScript = (Hand)HandL.GetComponent("Hand");
        HandScript.CatchBallLeft();
        HandRight HandRight = (HandRight)HandR.GetComponent("HandRight");
        HandRight.CatchBallLeft();
    }

    public void rightplayercatch()
    {
        Thrower RightScript = (Thrower)AJR.GetComponent("Thrower");
        RightScript.RightPlayerCatch();
        Thrower RightScriptP = (Thrower)PR.GetComponent("Thrower");
        RightScriptP.RightPlayerCatch();
    }

    public void leftplayercatch()
    {
        Player LeftScript = (Player)AJL.GetComponent("Player");
        LeftScript.LeftPlayerCatch();
        Player LeftScriptP = (Player)PL.GetComponent("Player");
        LeftScriptP.LeftPlayerCatch();
    }

    public void leftcatch()
    {
        Player LeftScript = (Player)AJL.GetComponent("Player");
        LeftScript.LeftCatch();
        Player LeftScriptP = (Player)PL.GetComponent("Player");
        LeftScriptP.LeftCatch();
    }

    public void rightcatch()
    {
        Thrower RightScript = (Thrower)AJR.GetComponent("Thrower");
        RightScript.RightCatch();
        Thrower RightScriptP = (Thrower)PR.GetComponent("Thrower");
        RightScriptP.RightCatch();
    }
}