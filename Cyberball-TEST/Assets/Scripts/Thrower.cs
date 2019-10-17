using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Thrower : MonoBehaviour {

    //create variable
    public GameObject Ball;
    public GameObject BallHandL;
    public GameObject parentA;
    public GameObject parentP;

    public JSONData set;
    static Animator anim;

    int rand;

    // Use this for initialization
    void Start () {
        string path = "C:/Users/computing/AppData/LocalLow/UROS/Cyberball-TEST/data.json";
        set = new JSONData(path);

        Debug.Log(set.Rounds);

        anim = GetComponent<Animator>();
        anim.SetBool("isHoldingBall", true); //initialise as holding ball
        BallHandL.transform.parent = parentA.transform;
        BallHandL.transform.parent = parentP.transform;
    }

	// Update is called once per frame
	void Update () {
            Ball.transform.parent = null;
    }

    public void Updater()
    {
        Sharer share = Ball.GetComponent<Sharer>();
        share.throws++;
    }

    public void randGen()
    {
        Sharer share = Ball.GetComponent<Sharer>();
        if (share.throws < set.Rounds)
        {
            rand = Random.Range(1, 3);
        }
        else
        {
            rand = 1;
        }
    }

    //wait random seconds
    IEnumerator WaitSeconds()
    {
        Sharer share = Ball.GetComponent<Sharer>();
        var randomWait = Random.Range(1, 4); //between 1 to 3 seconds

        if (share.throws < set.Rounds)
        {
            yield return new WaitForSeconds(randomWait); //call random fucntion
            randGen();
            Debug.Log("Random " + rand);
            if (set.GameMode == "Inclusive")
            {
                if (anim.GetBool("isHoldingBall")) //if holding a ball
                {
                    //Debug.Log("HoldBall");
                    if (rand == 1) //if random number is 1 throw to AI
                    {
                        anim.SetTrigger("isThrowing");
                        ThrowBall();
                    }
                    else //if random number is 2 the AI throws to the player
                    {
                        anim.SetTrigger("T2P");
                        ThrowBall();
                    }
                }
            }
            else
            {
                if (anim.GetBool("isHoldingBall")) //if holding a ball
                {
                    Debug.Log("share " + share.throws);
                    if (share.throws <= (set.Rounds / 2))
                    {
                        Debug.Log("HoldBall");
                        if (rand == 1) //if random number is 1 throw to AI
                        {
                            anim.SetTrigger("isThrowing");
                            ThrowBall();
                        }
                        else //if random number is 2 the AI throws to the player
                        {
                            anim.SetTrigger("T2P");
                            ThrowBall();
                        }
                    }
                    else
                    {
                        anim.SetTrigger("isThrowing");
                        ThrowBall();
                    }
                }
            }
        }
        else
        {
            share.popUp.SetActive(true);
            //SceneManager.LoadScene("Thank You");
        }
    }

    void ThrowBall() {
        anim.SetBool("isHoldingBall", false);
    }

    void ReleaseBall()
    {
        Sharer share = Ball.GetComponent<Sharer>();
        if (set.GameMode == "Inclusive")
        {
            if (rand == 1)
            {
                BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
                ballscript.Rel();
                Updater();
            }
            else
            {
                BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
                ballscript.RelPlayer();
                Updater();
            }
        }
        else
        {
            if (share.throws <= (set.Rounds / 2))
            {
                if (rand == 1)
                {
                    BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
                    ballscript.Rel();
                    Updater();
                }
                else
                {
                    BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
                    ballscript.RelPlayer();
                    Updater();
                }
            }
            else
            {
                BallScript ballscript = (BallScript)BallHandL.GetComponent("BallScript");
                ballscript.Rel();
                Updater();
            }
        }
        Debug.Log(share.throws);
    }

    public void catchMe()
    {
        Ball.SetActive(false);
        BallHandL.transform.parent = parentA.transform;
        BallHandL.transform.parent = parentP.transform;
        BallHandL.SetActive(true);
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