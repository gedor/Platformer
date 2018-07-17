using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartNewGame(){
		SceneManager.LoadScene("GameField");
	}
	public void ExitGame(){
		Application.Quit();
	}
}
