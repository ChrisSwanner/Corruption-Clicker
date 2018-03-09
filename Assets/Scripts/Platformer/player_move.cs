using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {
		
	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	private float moveX;
    public bool isGrounded;
    public float collisionValue = 0.7f; 

	void Update()
	{
		if (Input.GetKey("escape"))
			Application.Quit();
		PlayerMove ();
        PlayerRayCast();
	}

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }

        // Run animation
        if (moveX != 0) {
            GetComponent<Animator>().SetBool("isRunning", true);
        } else {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
		if (isGrounded == true)
		{
			GetComponent<Animator>().SetBool("isJumping", false);
		}
		else if (isGrounded == false)
		{
			GetComponent<Animator>().SetBool("isJumping", true);
		}


		if (moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;

		}

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;

	}


    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "ground") {
            isGrounded = true;
        }
		
    }

    void PlayerRayCast() {
		RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown.distance < collisionValue && rayDown.collider.tag == "enemy") {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 6;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }

	}

}
