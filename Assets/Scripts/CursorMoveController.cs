using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMoveController : MonoBehaviour {

		public Teleporter tel;
		
		public Camera cam;
		private float horizontal;
		private float vertical;
		
		public float cursSpeed;

		private bool horiInUse;
		private bool vertiInUse;

		
	// Use this for initialization
	void Awake () {
		
			}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		Vector2 currCursPos = CursorControl.GetGlobalCursorPos();

		
		Vector2 cursPos = new Vector2(currCursPos.x + horizontal *cursSpeed,currCursPos.y + vertical * cursSpeed * -1.0f);
		if(tel.teleTrigger == true){

			CursorControl.SetGlobalCursorPos(cursPos);
			
			//cam.transform.position += new Vector3 (horizontal * Time.deltaTime * cursSpeed, vertical * Time.deltaTime * cursSpeed, -10.0f);
		}
	}
}
