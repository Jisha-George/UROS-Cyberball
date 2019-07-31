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
        if (anim.GetBool("isHoldingBall"))
        {
            int t = Random.Range(1, 2);
            if(t == 1)
            {
                anim.SetTrigger("isThrowing");
            }
            else
            {
                anim.SetTrigger("T2P");
            }
        }
	}

    void ThrowBall() {
       BallScript ballscript = (BallScript)theball.GetComponent ("BallScript");
       ballscript.ReleaseMe();
    }

    void Throw()
    {
        BallScript ballscript = (BallScript)theball.GetComponent("BallScript");
        ballscript.Throw2Player();
        anim.SetTrigger("T2P");
        //theball.SetActive(false);
    }

    
    

}