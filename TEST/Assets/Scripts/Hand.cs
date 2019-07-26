using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public GameObject parentbone;
    public GameObject PlayerBall;
    static Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


    public void BallCatch()
    {
        PlayerBall.SetActive(true);

        PlayerBall.transform.parent = parentbone.transform;

    }




}
