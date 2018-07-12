using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover1 : MonoBehaviour {


	public float speed;
	private float move;

	private float moveJoy;
	public float jumpVelocity = 5.0f;
	public float fallMult = 5.5f;
	public float lowJumpMult = 5.0f;

	public bool facingRight;

	private bool canJump;
	private bool grounded = true;
	public Transform startPos, endPos;
	public LayerMask groundLayer;
	

	public int numbOfJumps = 0;
	public int numbOfPossJumps = 2;

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
		move = Input.GetAxisRaw("Horizontal");
		

	}
	void FixedUpdate() {
		RaycastHit2D hit = Physics2D.Linecast(startPos.position, endPos.position, groundLayer.value);
			 if (hit.collider != null){
        grounded = true;
		numbOfJumps = 0;
        playerAnim.SetBool("Jumping", false);
    	}

		
		rig.velocity = new Vector2 (move * speed,rig.velocity.y);
		

		playerAnim.SetFloat("Speed", Mathf.Abs(move));
		
		if(Input.GetButtonDown("Fire1")){
			
			if(grounded == true && canJump == true){
			rig.velocity = Vector2.up * jumpVelocity;
			playerAnim.SetBool("Jumping",true);
			
			numbOfJumps += 1;
			}
			
		
		}
		if(numbOfJumps >= numbOfPossJumps){
			canJump = false;
			}
			else if (numbOfJumps < numbOfPossJumps){
			canJump = true;
			}
		if(rig.velocity.y <0){

			rig.velocity += Vector2.up*Physics2D.gravity.y*(fallMult-1)*Time.deltaTime;

		}else if(rig.velocity.y > 0 && !Input.GetButton("Fire1")){
			rig.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;

		}
		if(move >0 && !facingRight){
			Flip();

		}
		else if(move < 0 && facingRight){
			Flip();
		}
	
			
	}
	void Flip(){
		facingRight = !facingRight;
	Vector3 theScale = transform.localScale;
	theScale.x *= -1;
	transform.localScale = theScale;
	}
	
}
