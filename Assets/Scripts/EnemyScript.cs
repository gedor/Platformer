using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public LayerMask enemyMask;
	private Rigidbody2D enemyRigid;
	Transform enemyTran;
	float myWidth;
	public float speed;
	
	// Use this for initialization
	void Start () {
		enemyTran = this.transform;
		enemyRigid = this.GetComponent<Rigidbody2D>();
		myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	Vector2 lineCastPos = enemyTran.position - enemyTran.right * myWidth;
	bool IsGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
	if(!IsGrounded){
		Vector3 currRot = enemyTran.eulerAngles;
		currRot.y += 180;
		enemyTran.eulerAngles = currRot;
	}
	MoveEnemy();
	}
	void MoveEnemy(){
		Vector2 myVel =enemyRigid.velocity;
		myVel.x = enemyTran.right.x * speed * Time.deltaTime;
		enemyRigid.velocity = myVel;
	}
}
