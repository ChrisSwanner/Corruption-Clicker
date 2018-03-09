using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerScore : MonoBehaviour {
    public GameObject timeLeftUI;
    public GameObject scoreUI;
    private float timeLeft = 60;
    private int score;


	private void OnTriggerEnter2D(Collider2D trig)
	{
        if (trig.gameObject.tag == "dollar")
            score += 100;
		Destroy(trig.gameObject);

		if (trig.gameObject.name == "EndLevel")
		{
			SceneManager.LoadScene("Platform2");

		}

	}

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
		scoreUI.gameObject.GetComponent<Text>().text = ("Score: " + score);

		if (timeLeft < 0.0f) {
            SceneManager.LoadScene("Platform1");
        }
        PlayerPrefs.GetFloat("currentMoney");


	}



}
