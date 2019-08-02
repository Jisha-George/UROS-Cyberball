using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Ball;
    public GameObject BallHandR;
    public GameObject parent;
    static Animator anim;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        BallHandR.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 BPos = Ball.transform.position;
        Vector3 RPos = BallHandR.transform.position;
        if (Vector3.Distance(RPos, BPos) <= 45.8) {
           // Debug.Log("RPos: " + Vector3.Distance(RPos, BPos));
            anim.SetTrigger("catch");
        }
    }

    public void catchMe(){
        BallHandR.SetActive(true);
        BallHandR.transform.parent = parent.transform;
        Ball.SetActive(false);
        anim.SetBool("isHoldingBall", true);
    }
}