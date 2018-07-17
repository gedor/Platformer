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
	private Vector3 minCamPos = new Vector3 (-8.0f,-15.0f, -10.0f);
	private Vector3 maxCamPos = new Vector3 (20.0f,-4.0f, -10.0f);

	private int screenWidth;
	private int screenHeight;
	private bool isCamMoving;
	private float speed = 5.0f;
	void Awake(){
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
	}
	void FixedUpdate(){
		
		if(tele.teleTrigger == true){
			MoveCam();
		//screenPoint =Input.mousePosition;
		//screenPoint.z = 10.0f;
		//transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
		}else{
			Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
		transform.position = smoothedPosition;
		}

			transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCamPos.x,maxCamPos.x),
			Mathf.Clamp(transform.position.y,minCamPos.y,maxCamPos.y),
			Mathf.Clamp(transform.position.z,minCamPos.z,maxCamPos.z));
		
	}
	void MoveCam()
     {
         Vector3 camPos = transform.position;
         if (Input.mousePosition.x > screenWidth - 30 && Input.mousePosition.y > screenHeight - 30)
         {
             isCamMoving = true;
             camPos.x += speed * Time.deltaTime;
			camPos.y += speed * Time.deltaTime;

         }
         else if (Input.mousePosition.x < 30 && Input.mousePosition.y < 30)
         {
             isCamMoving = true;
             camPos.x -= speed*Time.deltaTime;
			 camPos.y -= speed * Time.deltaTime;
         }
         
         else if (Input.mousePosition.x > screenWidth - 30 && Input.mousePosition.y < 30)
         {
             isCamMoving = true;
             camPos.x += speed*Time.deltaTime;
			 camPos.y -= speed * Time.deltaTime;
         }
         else if (Input.mousePosition.x < 30 && Input.mousePosition.y > screenHeight - 30)
         {
             isCamMoving = true;
			 camPos.x -= speed * Time.deltaTime;
             camPos.y += speed * Time.deltaTime;

         }else if(Input.mousePosition.x > screenWidth - 30){
			isCamMoving = true;
			camPos.x += speed * Time.deltaTime;
		 }
		 else if(Input.mousePosition.x < 30){
			 isCamMoving = true;
			 camPos.x -= speed*Time.deltaTime;
		 }else if(Input.mousePosition.y > screenHeight - 30){
			isCamMoving = true;
			camPos.y += speed * Time.deltaTime;
		 }
		 
		 else if(Input.mousePosition.y < 30){
			 isCamMoving = true;
			 camPos.y -= speed*Time.deltaTime;
		 }
         else 
         {
             isCamMoving = false;
         }
		 transform.position = camPos ;
     }
}
