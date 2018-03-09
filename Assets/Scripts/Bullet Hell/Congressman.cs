using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Congressman : MonoBehaviour {

	public float speed;
	private float timeBetweenShots;
	public float startTimeBetweenShots;
	public Transform player;
	AudioSource soundSource;
	public AudioClip hit1;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		soundSource = GameObject.FindGameObjectWithTag ("Player").GetComponent<AudioSource> ();
		soundSource.volume = 1f;

	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "Player") || (col.tag == "playerBullet")) {
			soundSource.PlayOneShot(hit1);

			Destroy (gameObject);
		}
	}
		
}
