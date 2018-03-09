﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerBoat : MonoBehaviour {

    Rigidbody2D rb;
    GameObject a, b, c, d;

    public ParticleSystem moneySplosion;
    public GameObject bullet;
    public GameObject pwUpBullet1;
    public GameObject pwUpBullet2;
    public GameObject playerHealthUI;

    public AudioClip explode;
    public AudioClip shoot;
    public AudioClip hit;

    public AudioSource soundSource;

    public float speed;
    public int delay = 2;
    public int health = 3;
    private bool isDead;
    private bool isPwdUp = false;

    public float gameOverDelay = 1.4f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
        c = transform.Find("c").gameObject;
        d = transform.Find("d").gameObject;

    }

    // Use this for initialization
    void Start () {
        soundSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        playerHealthUI.gameObject.GetComponent<Text>().text = ("Player Health: " + (int)health);

        if (isPwdUp)
        {
            
        }

        if (Input.GetKey("escape"))
            Application.Quit();

        if (!isDead)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
            rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

            if (isPwdUp && Input.GetKey(KeyCode.Space) && delay > 7)
            {
                PwUpShoot();
            }

            else if (!isPwdUp && Input.GetKey(KeyCode.Space) && delay > 10)
            {
                Shoot();
            }
            


        }

        if (isDead == true)
        {
            gameOverDelay -= Time.deltaTime;
            if (gameOverDelay <= 0)
            {
                SceneManager.LoadScene("boatGameOver");
            }


        }
        delay++;
    }


    public void Damage()
    {
        health--;
        soundSource.PlayOneShot(hit);
        if (health <= 0)
        {
            Invoke("MoneySplode", 0.7f);
            GetComponent<Animator>().SetBool("IsDead", true);
            isDead = true;
            soundSource.PlayOneShot(explode);
            Destroy(gameObject, 1.5f);
		}
           
    }

   
    public void Shoot()
    {
        soundSource.PlayOneShot(shoot);
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
        delay = 0;
    }

    public void PwUpShoot()
    {
        soundSource.PlayOneShot(shoot);
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
        Instantiate(pwUpBullet1, c.transform.position, Quaternion.identity);
        Instantiate(pwUpBullet2, d.transform.position, Quaternion.identity);
        delay = 0;
    }

    public void AddLife()
    {
        health++;
    }

    public void PwrUp()
    {
        isPwdUp = true;
        Invoke("PwrDown", 6.0f);
    }

    public void PwrDown()
    {
        isPwdUp = false;
    }

    public void MoneySplode()
    {
        moneySplosion.Play();
    }

}
