using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBall : MonoBehaviour {

    public GameObject Ball;
    public GameObject PlayerBall;

    static Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerRel()
    {
        Ball.transform.parent = null;
        PlayerBall.SetActive(false);
        anim.SetTrigger("PlayerThrowR");
        //Debug.Log("PlayerCatch!");
    }

    public void PlayerRelLeft()
    {
        Ball.transform.parent = null;
        PlayerBall.SetActive(false);
        anim.SetTrigger("PlayerThrowL");
        //Debug.Log("Player2Catch!");
    }
}
