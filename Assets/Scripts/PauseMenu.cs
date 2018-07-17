using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {


	CursorLockMode wantedMode;
	public Canvas pauseCanvas;
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
			Time.timeScale = 0.0f;
			

		}else if (pauseCanvas.enabled == true){
			
			Cursor.visible = false;
			Cursor.lockState = wantedMode;
			pauseCanvas.enabled = false;
			Time.timeScale = 1.0f;
			
			
			
			
		}
		}
	}
	public void ResumeGame(){
		Cursor.lockState = wantedMode;
		Cursor.visible = false;
		pauseCanvas.enabled = false;
		Time.timeScale = 1.0f;
		
		
		
			
	}
	public void ExitGame(){
		Application.Quit();
	}
}
