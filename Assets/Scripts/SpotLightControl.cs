using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightControl : MonoBehaviour {
	
	private Light spotLight;
	public LayerMask layerMask;
	private GameObject hand;

	void Start () {
		spotLight = GetComponent<Light>();
		hand = GameObject.Find ("RHand");
	}
	
	void Update () {
		followMouse();
	}

	void followMouse(){
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 origin = hand.transform.position;
		Vector3 dir = hand.transform.forward;
		float maximumHitDistance = 25.0f;
		RaycastHit hit;
	
		if(Physics.Raycast(origin, dir, out hit, maximumHitDistance, layerMask)){
			Vector3 target = hit.point;
			float yDistance = 2.0f;
			Vector3 updatedLightPosition = new Vector3(target.x, target.y + yDistance, target.z);		
			transform.position = updatedLightPosition;
			spotLight.enabled = true;
		}else{
			spotLight.enabled = false;
		}
	}
}
