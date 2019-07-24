using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Ball;
    public GameObject BallHandR;
    static Animator anim;
    public GameObject parent;

    //public bool holdingBall = true;

	// Use this for initialization
	void Start () {
        //ball.GetComponent<Rigidbody>().useGravity = false;
        anim = GetComponent<Animator>();
        BallHandR.SetActive(false);
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
        Vector3 BPos = Ball.transform.position;
        Vector3 RPos = BallHandR.transform.position;
        Debug.Log("RPos: " + Vector3.Distance(RPos, BPos));
        if (Vector3.Distance(RPos, BPos) <= 45.8)
        {
            Debug.Log("RPos: " + Vector3.Distance(RPos, BPos));
            anim.SetTrigger("catch");
        }
    }

    public void catchMe(){
        BallHandR.SetActive(true);
        BallHandR.transform.parent = parent.transform;
        Ball.SetActive(false);
    }
}
