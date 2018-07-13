using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {


	CursorLockMode wantedMode;
	public bool teleTrigger = false;
	public PlayerMover1 plaMov;
	
	
	// Use this for initialization
	void Start () {
		wantedMode = CursorLockMode.Locked;
		Cursor.lockState = wantedMode;
	}
	
	// Update is called once per frame
			void Update () {
		this.transform.Rotate(Vector3.forward * 10.0f * Time.deltaTime);
	}
	private void OnTriggerStay2D(Collider2D other) {
		if(Input.GetButtonDown("Fire2")){
				
				
				teleTrigger = true;
				Cursor.lockState = CursorLockMode.None; 
				
				

		}else if(Input.GetButtonDown("Fire3")){
			teleTrigger = false;
		//Cursor.visible = false;
		
		Cursor.lockState = wantedMode;
		
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		teleTrigger = false;
		//Cursor.visible = false;
		
		Cursor.lockState = wantedMode;
	}
}
