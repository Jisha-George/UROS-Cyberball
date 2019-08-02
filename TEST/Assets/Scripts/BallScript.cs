using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject BallHandL;
    public GameObject parentbone;
    public GameObject Ball;
    public GameObject MBall;

    static Animator anim;

    // Use this for initialization
    void Start () {
        transform.parent = parentbone.transform;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Rel()
    {
        anim.SetTrigger("Throwing");
        Ball.transform.parent = null;
        BallHandL.SetActive(false);
        Debug.Log("poof");
    }

    public void ThrowBall()
    {
        Ball.transform.parent = null;
        BallHandL.SetActive(false);
        anim.SetTrigger("T2P");
        Debug.Log("PlayerCatch!");
    }
}