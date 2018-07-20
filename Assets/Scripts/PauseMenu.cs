using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {


	CursorLockMode wantedMode;
	public Canvas pauseCanvas;
	public Teleporter  tele;
	public bool paused = false;


	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotspotZero = Vector2.zero;
	public Texture2D cursorTexture;

	public Texture2D cursorTele;
	public Vector2 hotspot;
	// Use this for initialization
	void Awake() {
		pauseCanvas.enabled = false;

		
	}
	void Start() {
		wantedMode = CursorLockMode.Locked;
		Cursor.lockState = wantedMode;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
			hotspot = new Vector2 (cursorTele.width/2,cursorTele.height/2);

		if(Input.GetButtonDown("Cancel")){
				if(pauseCanvas.enabled == false){

			pauseCanvas.enabled = true;
			Cursor.SetCursor(cursorTexture,hotspotZero,cursorMode);
			Cursor.lockState = CursorLockMode.None; 
			Cursor.visible = true;
			paused = true;
			Time.timeScale = 0.0f;
			

		}
			else if (pauseCanvas.enabled == true){
			


				if(tele.teleTrigger == false){

				Time.timeScale = 1.0f;
				Cursor.SetCursor(cursorTexture,hotspotZero,cursorMode);
			Cursor.visible = false;
			Cursor.lockState = wantedMode;
			pauseCanvas.enabled = false;
			paused = false;
			
				}
				else if(tele.teleTrigger == true){
				Time.timeScale = 1.0f;
				Cursor.lockState = CursorLockMode.None; 
				Cursor.visible = true;
				paused = false;
				pauseCanvas.enabled = false;
				Cursor.SetCursor(cursorTele,hotspot,cursorMode);

				}
			}
		}
	}
	public void ResumeGame(){
				if(tele.teleTrigger == false){
				Time.timeScale = 1.0f;
			Cursor.visible = false;
			Cursor.lockState = wantedMode;
			pauseCanvas.enabled = false;
			paused = false;
			
			}
			else if(tele.teleTrigger == true){
				Time.timeScale = 1.0f;
				Cursor.lockState = CursorLockMode.None; 
				Cursor.visible = true;
				paused = false;
				pauseCanvas.enabled = false;
				

			}
	}
	public void ExitGame(){
		Application.Quit();
	}
}
