using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScore : MonoBehaviour {

	public UnityEngine.UI.Text bulletTimeUI;
	public UnityEngine.UI.Text bulletKillsUI;
	public static bool hasWon;

	public int delay = 2;

	private float timeLeft = 60;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("Score", 0);
		PlayerPrefs.SetInt("Kills", 0);
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		bulletTimeUI.text = ("Time Left: " + (int)timeLeft);
		bulletKillsUI.text = ("Congressmen Paid: " + (PlayerPrefs.GetInt("Kills") + ""));

		if (timeLeft <= 0.0f) {
			hasWon = true;
				SceneManager.LoadScene("bulletWinScreen");
			

            }
		}
	}
