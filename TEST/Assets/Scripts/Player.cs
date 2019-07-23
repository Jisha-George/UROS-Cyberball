using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject ball;
    static Animator anim;

    public bool holdingBall = true;

	// Use this for initialization
	void Start () {
        //ball.GetComponent<Rigidbody>().useGravity = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (holdingBall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                holdingBall = false;
                //ball.GetComponent<Rigidbody>().useGravity = true;
                anim.SetTrigger("isThrowing");
            }
        }
	}
}
