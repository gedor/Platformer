using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {



	public Transform target;
	public float smoothSpeed;
	public Vector3 offset;

	private Vector3 screenPoint;

	public Teleporter tele;
	//public bool inBounds;
	private Vector3 minCamPos = new Vector3 (-2.35f,-13.25f, -10.0f);
	private Vector3 maxCamPos = new Vector3 (20.0f,-4.0f, -10.0f);

	
	void FixedUpdate(){
		
		
		if(tele.teleTrigger == true){
		screenPoint =Input.mousePosition;
		screenPoint.z = 10.0f;
		transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
		}else{
			Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
		transform.position = smoothedPosition;
		}

			transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCamPos.x,maxCamPos.x),
			Mathf.Clamp(transform.position.y,minCamPos.y,maxCamPos.y),
			Mathf.Clamp(transform.position.z,minCamPos.z,maxCamPos.z));
		
	}
}
