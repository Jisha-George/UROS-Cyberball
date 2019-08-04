using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRight : MonoBehaviour {

    public GameObject parent;
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
        Vector3 BPos = PlayerBall.transform.position;
        Vector3 RPos = movingBall.transform.position;
        
        if (Vector3.Distance(RPos, BPos) <= 200 && Vector3.Distance(RPos,BPos) >= 190)
        {
            Debug.Log("RPos: " + Vector3.Distance(RPos, BPos));
            anim.SetTrigger("Catching");
            
        }
    }


    public void BallCatch() {
        Vector3 BPos = PlayerBall.transform.position;
        Vector3 RPos = movingBall.transform.position;
        PlayerBall.SetActive(true);
        PlayerBall.transform.parent = parent.transform;
        //Debug.Log("PlayerBall:" + PlayerBall.transform.position);
        Debug.Log("RPos: " + Vector3.Distance(RPos, BPos));
        movingBall.SetActive(false);
        anim.SetBool("Ball", true);
    } 
    
    //if (holdingBall){
    //    if (Input.GetMouseButtonDown(0)){
    //        holdingBall = false;
    //        anim.SetTrigger("isThrowing");
    //    }
    //}
}
