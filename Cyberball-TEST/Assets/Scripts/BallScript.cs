using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject BallHandL;
    public GameObject BallHandR;
    public GameObject Ball;
    public GameObject HandL;
    public GameObject HandR;
    public GameObject BR;
    public GameObject BL;
    public GameObject GL;
    public GameObject GR;

    static Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = Ball.GetComponent<Animator>();
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
        Right RightScript = (Right)BR.GetComponent("Right");
        RightScript.RightPlayerCatch();
        Right RightScriptP = (Right)GR.GetComponent("Right");
        RightScriptP.RightPlayerCatch();
    }

    public void leftplayercatch()
    {
        Left LeftScript = (Left)BL.GetComponent("Left");
        LeftScript.LeftPlayerCatch();
        Left LeftScriptP = (Left)GL.GetComponent("Left");
        LeftScriptP.LeftPlayerCatch();
    }

    public void leftcatch()
    {
        Left LeftScript = (Left)BL.GetComponent("Left");
        LeftScript.LeftCatch();
        Left LeftScriptP = (Left)GL.GetComponent("Left");
        LeftScriptP.LeftCatch();
    }

    public void rightcatch()
    {
        Right RightScript = (Right)BR.GetComponent("Right");
        RightScript.RightCatch();
        Right RightScriptP = (Right)GR.GetComponent("Right");
        RightScriptP.RightCatch();
    }
}