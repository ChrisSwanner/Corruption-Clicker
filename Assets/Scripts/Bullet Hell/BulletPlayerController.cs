﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BulletPlayerController : MonoBehaviour 
{
	public bool moving = false;
	public bool spitting = false;
	private float speed = 3f;
	public int counter = 0;
	public bool mouthPos = false;
	public int health = 4;
	public bool isDead = false;
	public GameObject moneyBulletObject;
	GameObject rightMouth, leftMouth, bullet;
	private List<GameObject> Projectiles = new List<GameObject>();
	public GameObject playerHealthUI;
	public AudioSource soundSource;
	public AudioClip hit;

	void Awake() {

		rightMouth = transform.Find ("rightMouth").gameObject;

		leftMouth = transform.Find ("leftMouth").gameObject;

	}

	//Use this for initialization
	void Start () 
	{
		soundSource.volume = 1f;
	}
    public IEnumerator WaitForTime(float time) {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("bulletGameOver");
    }
	// Update is called once per frame
	void Update ()
	{
		playerHealthUI.gameObject.GetComponent<Text>().text = ("Player Health: " + (int)health);
        if (isDead == true) {
            GetComponent<Animator>().SetBool("isDying", true);
            StartCoroutine(WaitForTime(2.0f));

        }
			
		if (isDead == false) 
		{
			if (spitting == true) {
				counter++;
			}

			if (counter >= 4) {
				GetComponent<Animator> ().SetBool ("isSpitting", false);
				counter = 0;
				spitting = false;
			}

			GetShootDirection ();

			movement ();

			if (moving == true && spitting == false) {
				GetComponent<Animator> ().SetBool ("isRunning", true);
			} else {
				GetComponent<Animator> ().SetBool ("isRunning", false);
			}
		}
	}

	void movement()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World);
			GetComponent<SpriteRenderer>().flipX = false;
			moving = true;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime, Space.World);
			GetComponent<SpriteRenderer>().flipX = false;
			moving = true;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.down * speed * Time.deltaTime, Space.World);
			GetComponent<SpriteRenderer>().flipX = true;
			moving = true;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime, Space.World);
			GetComponent<SpriteRenderer>().flipX = true;
			moving = true;
		}
		if (Input.GetKey (KeyCode.W) != true && Input.GetKey (KeyCode.D) != true && Input.GetKey (KeyCode.S) != true && Input.GetKey (KeyCode.A) != true) {
			moving = false;
		}
	}

	void GetShootDirection()
	{
		if ((Input.GetKeyDown (KeyCode.UpArrow)) || (Input.GetKeyDown (KeyCode.DownArrow)) || (Input.GetKeyDown (KeyCode.RightArrow)) || (Input.GetKeyDown (KeyCode.LeftArrow))) {
			if ((Input.GetKey (KeyCode.UpArrow)) && (Input.GetKey (KeyCode.RightArrow))) {
				moneyBullet.yAxis = 6;
				moneyBullet.xAxis = 6;
			} else if ((Input.GetKey (KeyCode.UpArrow)) && (Input.GetKey (KeyCode.LeftArrow))) {
				moneyBullet.yAxis = 6;
				moneyBullet.xAxis = -6;
			} else if ((Input.GetKey (KeyCode.DownArrow)) && (Input.GetKey (KeyCode.RightArrow))) {
				moneyBullet.yAxis = -6;
				moneyBullet.xAxis = 6;
			} else if ((Input.GetKey (KeyCode.DownArrow)) && (Input.GetKey (KeyCode.LeftArrow))) {
				moneyBullet.yAxis = -6;
				moneyBullet.xAxis = -6;
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				moneyBullet.yAxis = 6;
				moneyBullet.xAxis = 0;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				moneyBullet.yAxis = -6;
				moneyBullet.xAxis = 0;
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				GetComponent<SpriteRenderer>().flipX = true;
				mouthPos = true;
				moneyBullet.yAxis = 0;
				moneyBullet.xAxis = -6;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				GetComponent<SpriteRenderer>().flipX = false;
				mouthPos = false;
				moneyBullet.yAxis = 0;
				moneyBullet.xAxis = 6;
			}
			GetComponent<Animator> ().SetBool ("isSpitting", true);
			spitting = true;
			if (mouthPos == false) {
				bullet = (GameObject)Instantiate (moneyBulletObject, rightMouth.transform.position, Quaternion.identity);
				Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D>(), GetComponent<Collider2D> (), true);
				Projectiles.Add (bullet);
			} else {
				bullet = (GameObject)Instantiate (moneyBulletObject, leftMouth.transform.position, Quaternion.identity);
				Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D>(), GetComponent<Collider2D> (), true);
				Projectiles.Add (bullet);
			}


			shoot ();
		}
	}

	void shoot()
	{
		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (0, 1) * Time.deltaTime * speed);

				Vector3 bulletScreenPosition = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if ((bulletScreenPosition.y >= Screen.height) || (bulletScreenPosition.y <= 0) || (bulletScreenPosition.x <= -Screen.width) || (bulletScreenPosition.x >= Screen.width)) {
					DestroyObject (goBullet);
					Projectiles.Remove (goBullet);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
			if ((col.tag == "enemy") || (col.tag == "enemyBullet")) {
				if (health > 0) {
					health--;
					soundSource.PlayOneShot(hit);
				}
			else if (health == 0) {
					isDead = true;
					
					//soundSource.PlayOneShot(death);
				}
			} else {
				col.isTrigger = false;
			}

	}
}

