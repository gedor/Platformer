using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {


	public float speed;
	private float move;

	private float jumpVelocity = 5.0f;
	private float fallMult = 5.5f;
	private float lowJumpMult = 5.0f;

	public bool facingRight;

	private bool canJump = true;
	public Transform startPos, endPos;
	public LayerMask groundLayer;
	private bool canDoubleJump = true;

	Rigidbody2D rig;
	Animator playerAnim;

	// Use this for initialization
	void Awake() {
		rig = GetComponent<Rigidbody2D>();
		playerAnim = GetComponent<Animator>();
		facingRight = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		move = Input.GetAxis("Horizontal");
		
	}
	void FixedUpdate() {
		rig.velocity = new Vector2 (move * speed,rig.velocity.y);
		
		playerAnim.SetFloat("Speed", Mathf.Abs(move));
		
		if(Input.GetButtonDown("Jump")){
		if(canJump == true){
			
			rig.velocity = Vector2.up * jumpVelocity;
			playerAnim.SetBool("Jumping",true);
			canDoubleJump = true;
			canJump = false;
			
		}else if (canDoubleJump == true){

			rig.velocity = Vector2.up * jumpVelocity;
			playerAnim.SetBool("Jumping",true);
			canDoubleJump = false;
			canJump = false;
		}
		}
		if(rig.velocity.y <0){

			rig.velocity += Vector2.up*Physics2D.gravity.y*(fallMult-1)*Time.deltaTime;

		}else if(rig.velocity.y > 0 && !Input.GetButton("Jump")){
			rig.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;

		}
		if(move >0 && !facingRight){
			Flip();

		}
		else if(move < 0 && facingRight){
			Flip();
		}
	
			RaycastHit2D hit = Physics2D.Linecast(startPos.position, endPos.position, groundLayer.value);
			 if (hit.collider != null)
    	{
        canJump = true;
		canDoubleJump = true;
        playerAnim.SetBool("Jumping", false);

    	}else if(hit.collider == null){
			canJump = false;
			canDoubleJump = true;
		}
	}
	void Flip(){
		facingRight = !facingRight;
	Vector3 theScale = transform.localScale;
	theScale.x *= -1;
	transform.localScale = theScale;
	}
	
}
