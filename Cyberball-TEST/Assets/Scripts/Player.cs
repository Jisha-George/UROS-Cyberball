using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Ball;
    public GameObject BallHandR;
    public GameObject parent;
    

    public JSONData set;
    static Animator anim;
   
    int rand;
    int throws;
    int round;
    int tUpdate = 0;


    // Use this for initialization
    void Start () {
        string path = "C:/Users/computing/AppData/LocalLow/UROS/Cyberball-TEST/data.json";
        set = new JSONData(path);
        round = set.Rounds;

        Sharer share = Ball.GetComponent<Sharer>();
        tUpdate = share.throws;

        anim = GetComponent<Animator>();
        anim.SetBool("isHoldingBall", false);
        BallHandR.SetActive(false);
        BallHandR.transform.parent = parent.transform;
    }
	
	// Update is called once per frame
	void Update () {
        Sharer share = Ball.GetComponent<Sharer>();
        share.throws = tUpdate;
    }

    public void randGen()
    {
        rand = Random.Range(1, 3);
    }

    IEnumerator WaitSeconds()
    {
        var randomWait = Random.Range(1, 4); //between 1 to 3 seconds
        if (tUpdate < round)
        {
            yield return new WaitForSeconds(randomWait); //call random fucntion
            //Debug.Log("Waiting " + randomWait);
            randGen();
            //Debug.Log("Random " + rand);

            if (set.GameMode == "Inclusive")
            {
                if (anim.GetBool("isHoldingBall")) //if holding a ball
                {
                    //Debug.Log("HoldBall");
                    if (rand == 1) //if random number is 1 throw to AI
                    {
                        anim.SetTrigger("isThrowing");
                        //Debug.Log("Thrown");
                        throws++;
                        ThrowBall();
                    }
                    else //if random number is 2 the AI throws to the player
                    {
                        anim.SetTrigger("L2P");
                        //Debug.Log("PlayerThrow");
                        throws++;
                        ThrowBall();
                    }
                }
            }
            else
            {
                if (anim.GetBool("isHoldingBall")) //if holding a ball
                {
                    if (throws <= round / 2)
                    {
                        //Debug.Log("HoldBall");
                        if (rand == 1) //if random number is 1 throw to AI
                        {
                            anim.SetTrigger("isThrowing");
                            //Debug.Log("Thrown");
                            throws++;
                            ThrowBall();
                        }
                        else //if random number is 2 the AI throws to the player
                        {
                            anim.SetTrigger("L2P");
                            //Debug.Log("PlayerThrow");
                            throws++;
                            ThrowBall();
                        }
                    }
                    else
                    {
                        anim.SetTrigger("isThrowing");
                        //Debug.Log("Thrown");
                        throws++;
                        ThrowBall();
                    }
                }
            }
        }
        else
        {
            popUp.SetActive(true);
            //SceneManager.LoadScene("Thank You");
        }
    }

    void ThrowBall()
    {
        anim.SetBool("isHoldingBall", false);
    }

    void ReleaseBall()
    {
        if (set.GameMode == "Inclusive")
        {
            if (rand == 1)
            {
                BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                ballscript.RelL();
            }
            else
            {
                BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                ballscript.RelPlayerL();
            }
        }
        else
        {
            if (throws <= (round / 2))
            {
                if (rand == 1)
                {
                    BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                    ballscript.RelL();
                }
                else
                {
                    BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                    ballscript.RelPlayerL();
                }
            }
            else
            {
                BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                ballscript.RelL();
            }
        }
    }

    public void LeftPlayerCatch()
    {
        anim.SetTrigger("P2L");
    }

    public void LeftCatch()
    {
        anim.SetTrigger("catch");
    }

    public void catchMe(){
        BallHandR.SetActive(true);
        BallHandR.transform.parent = parent.transform;
        Ball.SetActive(false);
        anim.SetBool("isHoldingBall", true);
        anim.ResetTrigger("P2L");
    }
}