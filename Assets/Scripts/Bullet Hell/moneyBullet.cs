using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyBullet : MonoBehaviour {

	public float speed = 6f;
	public static int xAxis = 0;
	public static int yAxis = 0;
	Rigidbody2D r2d;




	void Awake()
	{
		r2d = GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		r2d.velocity = new Vector2 (xAxis, yAxis);
	
	}

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "enemy") {
			PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills") + 1);
			Destroy (gameObject);
		}
	}


}
