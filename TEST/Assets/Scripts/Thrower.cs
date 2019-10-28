using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    //create variables
    public GameObject theball;
    static Animator anim;
    float randomWait;
    int rand;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isHoldingBall", true); //initialise as holding ball
        rand = Random.Range(2, 3);
    }

	// Update is called once per frame
	void Update () {
        
	}

    //wait random seconds
    IEnumerator WaitSeconds()
    {
        var randomWait = Random.Range(1, 4); //between 1 to 3 seconds
        yield return new WaitForSeconds(randomWait); //call random fucntion
        Debug.Log("Waiting " + randomWait);

        if (anim.GetBool("isHoldingBall")) //if holding a ball
        {
            Debug.Log("HoldBall");
            
            if (rand == 1) //if random number is 1 throw to AI
            {
                anim.SetTrigger("isThrowing");
                Debug.Log("Thrown");
                ThrowBall();
            }
            else //if random number is 2 the AI throws to the player
            {
                Debug.Log("PlayerThrow");
                ThrowBall();
                anim.SetTrigger("T2P");
            }
        }
    }

    void ThrowBall() {
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
            ballscript.RelPlayer();
        }
    }
}