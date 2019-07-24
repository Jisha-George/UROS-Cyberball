using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Ball;
    public GameObject BallHandR;
    static Animator anim;

    //public bool holdingBall = true;

	// Use this for initialization
	void Start () {
        //ball.GetComponent<Rigidbody>().useGravity = false;
        anim = GetComponent<Animator>();
       // BallHandR.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        //if (holdingBall)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        holdingBall = false;
        //        //ball.GetComponent<Rigidbody>().useGravity = true;
        //        anim.SetTrigger("isThrowing");
        //    }
        //}


        //if (Vector3.Distance(Ball.transform.position, BallHandR.transform.position) >= 1)
        //{
        //    anim.SetTrigger("isCatching");
        //   // BallHandR.SetActive(true);
        //  //  Ball.SetActive(false);
        //}
    }
}
