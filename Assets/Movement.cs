using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public int speed;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        movePlayer();
    }

    public void movePlayer()
    {
        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        float xMove = stick.x * Time.deltaTime;
        float yMove = stick.y * Time.deltaTime;

        this.transform.Translate(Vector3.forward * yMove);
        this.transform.Rotate(Vector3.up * 30 * xMove);
    }
}
