using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {


	CursorLockMode wantedMode;
	public Canvas pauseCanvas;
	public Teleporter  tele;
	public bool paused = false;
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
		if(Input.GetButtonDown("Cancel")){
		if(pauseCanvas.enabled == false){

			pauseCanvas.enabled = true;
			Cursor.lockState = CursorLockMode.None; 
			Cursor.visible = true;
			paused = true;
			Time.timeScale = 0.0f;
			

		}else if (pauseCanvas.enabled == true){
			


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
