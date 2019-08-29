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
        anim.SetTrigger("isThrowing");
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

    public void RelL()
    {
        anim.SetTrigger("Throw");
        Ball.transform.parent = null;
        BallHandR.SetActive(false);
        Ball.SetActive(true);
        Debug.Log("Right");
    }

    public void RelPlayerL()
    {
        Ball.transform.parent = null;
        BallHandR.SetActive(false);
        Ball.SetActive(true);
        anim.SetTrigger("L2P");
        Debug.Log("PlayerCatch!");
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
    }

    public void leftplayercatch()
    {
        Player LeftScript = (Player)AJL.GetComponent("Player");
        LeftScript.LeftPlayerCatch();
    }

    public void leftcatch()
    {
        Player LeftScript = (Player)AJL.GetComponent("Player");
        LeftScript.LeftCatch();
    }

    public void rightcatch()
    {
        Thrower RightScript = (Thrower)AJR.GetComponent("Thrower");
        RightScript.RightCatch();
    }
}