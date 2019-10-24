using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Right : MonoBehaviour {

    //create variables
    public GameObject Ball;
    public GameObject BallHandL;
    public GameObject parentB;
    public GameObject parentG;
    public GameObject BR;
    public GameObject GR;
    //public GameObject SR;
    //public GameObject JR;

    public JSONData set;
    static Animator anim;

    int rand;

    // Use this for initialization
    void Start () {
        string path = (Application.streamingAssetsPath + "/data.json");
        set = new JSONData(path);

        //Debug.Log(set.Rounds);

        if (set.Age == "Child")
        {
            if (set.Gender == "Only Girls")
            {
                anim = GR.GetComponent<Animator>();
            }
            else
            {
                anim = BR.GetComponent<Animator>();
            }
        }
        //else
        //{
        //    if(set.Gender == "Only Girls")
        //    {
        //        anim = SR.GetComponent<Animator>();
        //    }
        //    else
        //    {
        //        anim = JR.GetComponent<Animator>();
        //    }
        //}

        anim.SetBool("isHoldingBall", true); //initialise as holding ball

        if (set.Gender == "Only Girls")
        {
            BallHandL.transform.parent = parentG.transform;
        }
        else
        {
            BallHandL.transform.parent = parentB.transform;
            //Debug.Log(BallHandL.transform.localScale);
            //BallHandL.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            //BallHandL.transform.rotation = new Quaternion(0,0,0,0);
        }
        
        if (set.GameMode == "Random")
        {
            randGen(); 

            if(rand == 1)
            {
                set.GameMode = "Random Inclusive";
            }
            else
            {
                set.GameMode = "Random Exclusive";
            }
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
        Sharer share = Ball.GetComponent<Sharer>();
        if (share.throws < set.Rounds)
        {
            rand = Random.Range(1, 3);
        }
        else
        {
            rand = 1;
        }

        Debug.Log(rand);
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
            //Debug.Log("Random " + rand);
            if (set.GameMode == "Inclusive" || set.GameMode == "Random Inclusive")
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
                    //Debug.Log("share " + share.throws);
                    if (share.throws <= (set.Rounds / 2))
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
        if (set.GameMode == "Inclusive" || set.GameMode == "Random Inclusive")
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
        //Debug.Log(share.throws);
    }

    public void catchMe()
    {
        Ball.SetActive(false);
        Ball.transform.parent = null;
        if (set.Gender == "Only Girls")
        {
            BallHandL.transform.parent = parentG.transform;
        }
        else
        {
            BallHandL.transform.parent = parentB.transform;
        }
        BallHandL.SetActive(true);
        anim.SetBool("isHoldingBall", true);
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