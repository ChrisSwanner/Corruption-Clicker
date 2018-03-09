using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public bool isHealth;
    public bool isPwrUp;

    public AudioSource soundSource;
    public AudioClip repair;
    public AudioClip pwrUp;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10f);
        soundSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update () {
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (isHealth)
            {
                col.gameObject.GetComponent<PlayerBoat>().AddLife();
                soundSource.PlayOneShot(repair);
                Destroy(gameObject);
            }
            else if (isPwrUp)
            {
                col.gameObject.GetComponent<PlayerBoat>().PwrUp();
                soundSource.PlayOneShot(pwrUp);
                Destroy(gameObject);
            }
        }
    }
}
