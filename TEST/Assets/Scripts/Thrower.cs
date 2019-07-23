using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public GameObject theball;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ThrowBall() {
       BallScript ballscript = (BallScript)theball.GetComponent ("BallScript");
        ballscript.ReleaseMe();
    }
}