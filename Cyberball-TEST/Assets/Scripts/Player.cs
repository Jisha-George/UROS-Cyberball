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

    }

    public void LeftPlayerCatch()
    {
        
    }

    public void LeftCatch()
    {
        anim.SetTrigger("catch");
    }

    public void catchMe(){
        BallHandR.SetActive(true);
        BallHandR.transform.parent = parent.transform;
        Ball.SetActive(false);
        anim.SetBool("isHoldingBall", true);
    }
}