using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public GameObject parent;
    public GameObject PlayerBall;
    public GameObject Ball;
    static Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        PlayerBall.SetActive(false);
        PlayerBall.transform.parent = parent.transform;
        anim.SetBool("Ball", false);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void CatchBall()
    {
        anim.SetTrigger("Catching");
    }

    public void BallCatch() {
        PlayerBall.SetActive(true);
        Ball.SetActive(false);
        anim.SetBool("Ball", true);
    }

    public void BallThrow()
    {
       if (anim.GetBool("Ball"))
       {
            anim.SetBool("Ball", false);
            anim.SetTrigger("Throwing");
       }
    }

    public void ReleaseBall()
    {
        PlayerBall.SetActive(false);
        Ball.SetActive(true);
        HandBall handBall = (HandBall)Ball.GetComponent("HandBall");
        handBall.PlayerRel();
    }
}