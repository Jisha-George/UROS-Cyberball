using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject BallHandL;
    public GameObject parentbone;
    public GameObject Ball;

    static Animator anim;
    

    // Use this for initialization
    void Start () {
        transform.parent = parentbone.transform;
        anim = GetComponent<Animator>();
  
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 LPos = BallHandL.transform.position;
        Vector3 BPos = Ball.transform.position;
      //  Debug.Log(Vector3.Distance(LPos, BPos));

    }

   public void ReleaseMe() {
        Vector3 LPos = BallHandL.transform.position;
        Vector3 BPos = Ball.transform.position;

        if  (Vector3.Distance(LPos,BPos) >= 1){
            transform.parent = null;
            //rigid.useGravity = true;
            //transform.rotation = parentbone.transform.rotation;
            // rigid.AddForce(transform.forward * 40000);
            //rigid.AddForce(4.010345f, 3.13156f, 0, ForceMode.VelocityChange);
            anim.SetTrigger("throw");
            BallHandL.SetActive(false);
            
            Debug.Log("Lpos: " + Vector3.Distance(LPos, BPos));
            anim.SetBool("isHoldingBall",false);
        }
    }
}

