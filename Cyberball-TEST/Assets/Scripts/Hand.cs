using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

    public GameObject parent;
    public GameObject PlayerBall;
    public GameObject Ball;
    public Button Left, Right;
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
        if (anim.GetBool("Ball"))
        {
            Left.interactable = true;
            Right.interactable = true;
        }
        else
        {
            Left.interactable = false;
            Right.interactable = false;
        }
    }

    public void CatchBall()
    {
        anim.SetTrigger("Catching");
    }

    public void CatchBallLeft()
    {
        anim.SetTrigger("CatchLeft");
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
            anim.SetTrigger("Throwing");
            anim.SetBool("Ball", false);
        }
    }

    public void BallThrowLeft()
    {
        if (anim.GetBool("Ball"))
        {
            anim.SetTrigger("ThrowLeft");
            anim.SetBool("Ball", false);
        }
    }

    public void ReleaseBall()
    {
        PlayerBall.SetActive(false);
        Ball.SetActive(true);
        HandBall handBall = (HandBall)Ball.GetComponent("HandBall");
        handBall.PlayerRel();
    }

    public void ReleaseBallLeft()
    {
        PlayerBall.SetActive(false);
        Ball.SetActive(true);
        HandBall handBall = (HandBall)Ball.GetComponent("HandBall");
        handBall.PlayerRelLeft();
    }
}