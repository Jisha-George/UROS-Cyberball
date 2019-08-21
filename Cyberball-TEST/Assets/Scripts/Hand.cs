using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public GameObject parent;
    public GameObject PlayerBall;
    public GameObject movingBall;
    static Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        PlayerBall.SetActive(false);
        anim.SetBool("Ball", false);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 BPos = PlayerBall.transform.position;
        Vector3 RPos = movingBall.transform.position;
        
        if (Vector3.Distance(RPos, BPos) <= 200 && Vector3.Distance(RPos,BPos) >= 190)
        {
            anim.SetTrigger("Catching");
        }
    }

    public void BallCatch() {
        PlayerBall.SetActive(true);
        PlayerBall.transform.parent = parent.transform;
        movingBall.SetActive(false);
        anim.SetBool("Ball", true);
    }

    private void OnMouseDown()
    {
       if (anim.GetBool("Ball")){
            anim.SetTrigger("Throwing");
       }
    }
}
