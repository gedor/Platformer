using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorImageManager : MonoBehaviour {

	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotspot = Vector2.zero;
	public Texture2D cursorTexture;
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(this);
		Cursor.SetCursor(cursorTexture,hotspot,cursorMode);
	}
}
