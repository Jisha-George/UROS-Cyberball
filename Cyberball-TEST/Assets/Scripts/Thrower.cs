using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    //create variable
    public GameObject Ball;
    public GameObject BallHandL;
    public GameObject parent;
    static Animator anim;
    float randomWait;
    int rand;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isHoldingBall", true); //initialise as holding ball
        BallHandL.transform.parent = parent.transform;
    }

	// Update is called once per frame
	void Update () {

    }

    public void randGen()
    {
        rand = Random.Range(1, 3);
       
    }

    //wait random seconds
    IEnumerator WaitSeconds()
    {
        var randomWait = Random.Range(1, 4); //between 1 to 3 seconds
        yield return new WaitForSeconds(randomWait); //call random fucntion
        Debug.Log("Waiting " + randomWait);
        randGen();
        Debug.Log("Random " + rand);

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
                anim.SetTrigger("T2P");
                Debug.Log("PlayerThrow");
                ThrowBall();
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
            BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
            ballscript.Rel();
        }
        else
        {
            BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
            ballscript.RelPlayer();
        }
    }

    public void catchMe()
    {
        BallHandL.SetActive(true);
        BallHandL.transform.parent = parent.transform;
        Ball.SetActive(false);
        anim.SetBool("isHoldingBall", true);
        anim.ResetTrigger("P2T");
    }

    public void RightPlayerCatch()
    {
        anim.SetTrigger("P2T");
    }

    public void RightCatch()
    {
        anim.SetTrigger("isCatching");
    }
}