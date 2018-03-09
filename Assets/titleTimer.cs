using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class titleTimer : MonoBehaviour {

    public GameObject timerUI;
    public float timer = 6;


	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
        timerUI.gameObject.GetComponent<TextMesh>().text = ("Big Bad Business Boy");

        if (timer < 0.0f) {
            Destroy(gameObject);
        }

	}
}
