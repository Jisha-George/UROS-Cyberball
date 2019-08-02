using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public GameObject theball;
    static Animator anim;
    public float randomWait;
    public int rand;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isHoldingBall", true);
        rand = Random.Range(2, 3);
    }


	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator WaitSeconds()
    {
        var randomWait = Random.Range(3, 7);
        yield return new WaitForSeconds(randomWait);
        Debug.Log("Waiting " + randomWait);

        if (anim.GetBool("isHoldingBall"))
        {
            Debug.Log("HoldBall");
            
            if (rand == 1)
            {
                anim.SetTrigger("isThrowing");
                Debug.Log("Thrown");
                ThrowBall();
            }
            else
            {
                Debug.Log("Throw2Player");
                ThrowPlayer();
                anim.SetTrigger("T2P");
            }
        }
    }

    void ThrowBall() {
        Debug.Log("Release");
        anim.SetBool("isHoldingBall", false);
    }

    void ThrowPlayer()
    {
        Debug.Log("PlayerThrow");
        anim.SetBool("isHoldingBall", false);
    }

    void ReleaseBall()
    {
        if (rand == 1)
        {
            BallScript ballscript = (BallScript)theball.GetComponent("BallScript");
            ballscript.Rel();
        }
        else
        {
            BallScript ballscript = (BallScript)theball.GetComponent("BallScript");
            ballscript.ThrowBall();
        }
    }
}