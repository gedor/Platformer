using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMoveController : MonoBehaviour {

		public Teleporter tel;
		
		public Camera cam;
		private float horizontal;
		private float vertical;
		//public float cursSpeed;

	// Use this for initialization
	void Awake () {
		
			}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		Vector2 currCursPos = CursorControl.GetGlobalCursorPos();
		Vector2 cursPos = new Vector2(currCursPos.x + horizontal,currCursPos.y + vertical * -1.0f);
		if(tel.teleTrigger == true){

			CursorControl.SetGlobalCursorPos(cursPos);
		}
	}
}
