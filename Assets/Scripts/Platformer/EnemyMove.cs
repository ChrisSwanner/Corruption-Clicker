using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
    private bool facingRight = false;
    public static bool hasLost;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        if (hit.distance < 0.3f)
        {
            Flip();
            flipAxis();
            if (hit.collider.tag == "Player")
            {
                hasLost = true;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 6;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                SceneManager.LoadScene("platformGameOver");
                hasLost = false;
            }
        }
    }


    void Flip () {
        if (XMoveDirection > 0) {
            XMoveDirection = -1;
        } else {
            XMoveDirection = 1;
        }
    }

    void flipAxis () {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
    }


}
