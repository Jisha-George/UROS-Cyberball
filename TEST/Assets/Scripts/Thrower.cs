using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public GameObject theball;
    static Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ThrowBall() {
       BallScript ballscript = (BallScript)theball.GetComponent ("BallScript");
        ballscript.ReleaseMe();
    }

    void Throw()
    {
        anim.SetTrigger("isThrowing");
        //theball.SetActive(false);
    }
}