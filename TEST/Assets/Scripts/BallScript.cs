using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject parentbone;
  //  public Rigidbody rigid;
   // public Vector3 lasPos;
   // public Vector3 curVel;
    static Animator anim;

    // Use this for initialization
    void Start () {
        transform.parent = parentbone.transform;
        //rigid.useGravity = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   public void ReleaseMe() {
        transform.parent = null;
        //rigid.useGravity = true;
        transform.rotation = parentbone.transform.rotation;
        // rigid.AddForce(transform.forward * 40000);
        //rigid.AddForce(4.010345f, 3.13156f, 0, ForceMode.VelocityChange);

       anim.SetTrigger("throw");
    }
}

