using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour {

    Rigidbody2D rb;
    GameObject a, b;
    public GameObject tankBullet1, tankBullet2, bullet, healthPwrUp, gunPwrUp;
    PolygonCollider2D collider;
    public AudioSource soundSource;
    public AudioClip laser;
    public AudioClip explode;
    public AudioClip cannon;
    public AudioClip bigExplode;


    public float xSpeed;
    public float ySpeed;

    public bool isTank;
    public bool canShoot;
    private bool isDead = false;

    public float fireRate;
    public float health;

    public int score;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        if (isTank)
        {
            a = transform.Find("a").gameObject;
            b = transform.Find("b").gameObject;
        }
 
    }

    // Use this for initialization
    void Start () {
        soundSource.volume = 0.5f;

        collider = GetComponent<PolygonCollider2D>();
        if (!canShoot)
        {
            Destroy(gameObject, 10);

        }
        else if (canShoot && !isTank)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
            Destroy(gameObject, 10);
        }

        else if (isTank)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
            InvokeRepeating("TankShoot", fireRate, fireRate);
            Destroy(gameObject, 30);
        }
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(xSpeed, ySpeed*-1);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerBoat>().Damage();
            Damage();
        }
    }

    public void Damage()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
        health--;
        if(health == 0)
        {
            Die();
        }
    }

    void Die()
    {
        if ((int)Random.Range(0, 2) == 0)
        {
            Instantiate(healthPwrUp, transform.position, Quaternion.identity);
        }
        else if ((int)Random.Range(0,2)==0)
        {
            Instantiate(gunPwrUp, transform.position, Quaternion.identity);
        }

        collider.enabled = !collider.enabled;
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills") + 1);
        isDead = true;
        GetComponent<Animator>().SetBool("isDead", true);
        Destroy(gameObject, 1.09f);

        if (isTank)
        {
            soundSource.PlayOneShot(bigExplode);
        }
        else
        {
            soundSource.PlayOneShot(explode);
        }
    }

    void Shoot()
    {
        if (!isDead)
        {
            GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            temp.GetComponent<Bullet>().ChangeYDirection();
            if (!isTank)
            {
                soundSource.PlayOneShot(laser);
            }
        }

    }

    void TankShoot()
    {
        if(!isDead)
        {
            Instantiate(tankBullet1, a.transform.position, Quaternion.identity);
            Instantiate(tankBullet2, b.transform.position, Quaternion.identity);
            soundSource.PlayOneShot(cannon);
        }
    }
}
