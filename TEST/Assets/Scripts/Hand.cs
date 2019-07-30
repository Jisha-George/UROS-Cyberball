using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public GameObject parent;
    public GameObject PlayerBall;
    public GameObject movingBall;
    static Animator anim;

	// Use this for initialization
	void Start () {
        PlayerBall.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}


    public void BallCatch() {
        PlayerBall.transform.parent = parent.transform;
        Debug.Log("PlayerBall:" + PlayerBall.transform.position);
        PlayerBall.SetActive(true);
        movingBall.SetActive(false);
    }
}
