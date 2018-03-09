using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class platform2NextLevel : MonoBehaviour
{
	public GameObject timeLeftUI;
	public GameObject scoreUI;
	private float timeLeft = 60;
	private int score;
    public static bool hasWon = false;


	private void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.tag == "level2Dollar")
			score += 100;
		Destroy(trig.gameObject);

		if (trig.gameObject.name == "EndLevel2")
		{
            hasWon = true;
			PlayerPrefs.GetFloat("currentMoney");

			SceneManager.LoadScene("CorruptionClicker");
		}
	}
	// Update is called once per frame
	void Update()
	{
		timeLeft -= Time.deltaTime;
		timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
		scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + score);

		if (timeLeft < 0.0f)
		{
			SceneManager.LoadScene("Platform1");
		}
	}
}
