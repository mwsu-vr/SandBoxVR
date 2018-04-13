using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Relative : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveHands();
	}

    void moveHands(){
        Vector3 parentPos = this.GetComponentInParent<Transform>().position;
        Vector3 handPos = this.transform.position;
        Vector3 offset = parentPos - handPos;

        this.transform.position = parentPos + offset;
    }
}
