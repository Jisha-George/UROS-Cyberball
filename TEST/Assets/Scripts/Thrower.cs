using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public GameObject theball;
    static Animator anim;
    public float randomWait;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isHoldingBall", true);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator WaitSeconds()
    {
        var randomWait = Random.Range(0, 5);
        yield return new WaitForSeconds(randomWait);

        if (anim.GetBool("isHoldingBall"))
        {   Debug.Log("HoldBall");
            int t = Random.Range(1, 3);
            if(t == 1)
            {
                ThrowBall(); 
                Debug.Log("Throwing");
            }
            else if (t == 2)
            {
                Throw();
                anim.SetTrigger("T2P");
                Debug.Log("Throw2Player");
            }
            else
            {
                anim.SetTrigger("Idle");
            }
        }
    }

    void ThrowBall() {
        BallScript ballscript = (BallScript)theball.GetComponent ("BallScript");
        ballscript.ReleaseMe();
        anim.SetBool("isHoldingBall", false);
    }

    void Throw()
    {
        BallScript ballscript = (BallScript)theball.GetComponent("BallScript");
        ballscript.Throw2Player();
        anim.SetBool("isHoldingBall", false);
    }

    
}