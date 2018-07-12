using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour {


	public GameObject player;
	public GameObject warp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			player.gameObject.transform.position = warp.transform.position;

		}
	}
}
