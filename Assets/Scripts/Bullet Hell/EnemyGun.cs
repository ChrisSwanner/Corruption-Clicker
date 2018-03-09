using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBullet, player;

	private float timeBetweenShots;
	public float startTimeBetweenShots;

	// Use this for initialization
	void Start () {
//		Invoke("FireEnemyBullet", 1f);
		player = GameObject.FindGameObjectWithTag ("Player");

		timeBetweenShots = startTimeBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			if (timeBetweenShots <= 0) {
				GameObject bullet = (GameObject)Instantiate (EnemyBullet);

				bullet.transform.position = transform.position;

				Vector2 direction = player.transform.position - bullet.transform.position;

				bullet.GetComponent<EnemyBullet> ().SetDirection (direction);

				timeBetweenShots = startTimeBetweenShots;
			} else {
				timeBetweenShots -= Time.deltaTime;
			}
		}
	}
}
