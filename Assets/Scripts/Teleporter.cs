using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {


	CursorLockMode wantedMode;
	public bool teleTrigger = false;
	public PlayerMover1 plaMov;
	
	public Transform playerTran;
	Vector3 mousPos;

	public CursorMode cursorMode = CursorMode.Auto;
	public Texture2D cursorTele;
	public Vector2 hotspot;

	public Vector2 hotspotZero = Vector2.zero;
	public Texture2D cursorTexture;
	// Use this for initialization
	void Start () {
		wantedMode = CursorLockMode.Locked;
		Cursor.lockState = wantedMode;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
			void Update () {
		this.transform.Rotate(Vector3.forward * 10.0f * Time.deltaTime);
		hotspot = new Vector2 (cursorTele.width/2,cursorTele.height/2);
		if(teleTrigger == true){
			if(Input.GetButtonDown("Fire1")){

				StartCoroutine ("TeleportPlayer");
			}
			
		}
		Vector2 mousPos = Input.mousePosition;
	}
	private void OnTriggerStay2D(Collider2D other) {
		if(Input.GetButtonDown("Fire2")){
				
				
				teleTrigger = true;
				Cursor.lockState = CursorLockMode.None; 
				Cursor.visible = true;
				
				Cursor.SetCursor(cursorTele,hotspot,cursorMode);
				

		}else if(Input.GetButtonDown("Fire3")){
			teleTrigger = false;
		//Cursor.visible = false;
		
		Cursor.lockState = wantedMode;
		Cursor.visible = false;

		Cursor.SetCursor(cursorTexture,hotspotZero,cursorMode);
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		teleTrigger = false;
		//Cursor.visible = false;
		
		Cursor.lockState = wantedMode;
		Cursor.visible = false;
		Cursor.SetCursor(cursorTexture,hotspotZero,cursorMode);

	}
	IEnumerator TeleportPlayer(){
		
		yield return new WaitForSeconds (1.0f);
		teleTrigger = false;
		Cursor.visible = false;
		Cursor.lockState = wantedMode;
		// playerTran.position = new Vector3 (Camera.main.ScreenToWorldPoint(CursorControl.GetGlobalCursorPos()).x,Camera.main.ScreenToWorldPoint(CursorControl.GetGlobalCursorPos()).y,0);
		playerTran.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
		Cursor.SetCursor(cursorTexture,hotspotZero,cursorMode);
	}
}
