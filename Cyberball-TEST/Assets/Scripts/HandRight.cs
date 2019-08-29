using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRight : MonoBehaviour {

    public GameObject PlayerBall;
    public GameObject movingBall;

    static Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        PlayerBall.SetActive(false);
        anim.SetBool("Ball", false);
       
    }
	
	// Update is called once per frame
	void Update () {

    }
    
    public void BallCatch() {
        movingBall.SetActive(false);
        anim.SetBool("Ball", true);
    }

    public void CatchBall()
    {
        anim.SetTrigger("Catching");
    }

    public void CatchBallLeft()
    {
        anim.SetTrigger("CatchLeft");
    }

    public void BallThrow()
    {
       if (anim.GetBool("Ball"))
       {
            anim.SetBool("Ball", false);
            anim.SetTrigger("Throwing");
       }
    }

    public void BallThrowLeft()
    {
        if (anim.GetBool("Ball"))
        {
            anim.SetBool("Ball", false);
            anim.SetTrigger("ThrowLeft");
        }
    }
}