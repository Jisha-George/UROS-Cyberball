using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Ball;
    public GameObject BallHandR;
    public GameObject parentA;
    public GameObject parentP;
    public GameObject AJL;
    public GameObject PL;

    public JSONData set;
    static Animator anim;
   
    int rand;

    // Use this for initialization
    void Start () {
        string path = (Application.streamingAssetsPath + "/data.json");
        set = new JSONData(path);

        if (set.Gender == "Only Boys")
        {
            anim = AJL.GetComponent<Animator>();
        }
        else
        {
            anim = PL.GetComponent<Animator>();
        }

        anim.SetBool("isHoldingBall", false);
        BallHandR.SetActive(false);


        if (set.Gender == "Only Boys")
        {
            //Debug.Log(set.Gender);
            BallHandR.transform.parent = parentA.transform;
        }
        else
        {
            BallHandR.transform.parent = parentP.transform;
        }
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
        rand = Random.Range(1, 3);
    }

    IEnumerator WaitSeconds()
    {
        Sharer share = Ball.GetComponent<Sharer>();
        var randomWait = Random.Range(1, 4); //between 1 to 3 seconds
        if (share.throws < set.Rounds)
        {
            yield return new WaitForSeconds(randomWait); //call random fucntion
            randGen();
          // Debug.Log("LRandom " + rand);

            if (set.GameMode == "Inclusive" || set.GameMode == "Random Inclusive")
            {
                if (anim.GetBool("isHoldingBall")) //if holding a ball
                {
                    if (rand == 1) //if random number is 1 throw to AI
                    {
                        anim.SetTrigger("isThrowing");
                        ThrowBall();
                    }
                    else //if random number is 2 the AI throws to the player
                    {
                        anim.SetTrigger("L2P");
                        ThrowBall();
                    }
                }
            }
            else
            {
                if (anim.GetBool("isHoldingBall")) //if holding a ball
                {
                   // Debug.Log("Share" + share.throws);
                    if (share.throws <= (set.Rounds / 2))
                    {
                       
                        if (rand == 1) //if random number is 1 throw to AI
                        {
                            anim.SetTrigger("isThrowing");
                            ThrowBall();
                        }
                        else //if random number is 2 the AI throws to the player
                        {
                            
                            anim.SetTrigger("L2P");
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

    void ThrowBall()
    {
        anim.SetBool("isHoldingBall", false);
    }

    void ReleaseBall()
    {
        Sharer share = Ball.GetComponent<Sharer>();
        if (set.GameMode == "Inclusive" || set.GameMode == "Random Inclusive")
        {
            if (rand == 1)
            {
                BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                ballscript.RelL();
                Updater();
            }
            else
            {
                BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                ballscript.RelPlayerL();
                Updater();
            }
        }
        else
        {
            if (share.throws <= (set.Rounds / 2))
            {
                if (rand == 1)
                {
                    BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                    ballscript.RelL();
                    Updater();
                }
                else
                {
                    Debug.Log("HoldBall");
                    BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                    ballscript.RelPlayerL();
                    Updater();
                }
            }
            else
            {
                BallScript ballscript = (BallScript)BallHandR.GetComponent("BallScript");
                ballscript.RelL();
                Updater();
            }
        }
//        Debug.Log(share.throws);
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
        Ball.SetActive(false);
        Ball.transform.parent = null;
        if (set.Gender == "Only Boys")
        {
            //Debug.Log(set.Gender);
            BallHandR.transform.parent = parentA.transform;
        }
        else
        {

            BallHandR.transform.parent = parentP.transform;
        }
        BallHandR.SetActive(true);
        anim.SetBool("isHoldingBall", true);
    }
}