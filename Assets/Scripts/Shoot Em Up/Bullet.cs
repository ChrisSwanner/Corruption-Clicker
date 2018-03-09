using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    int yDir = 1;
    public bool isTankBullet1;
    public bool isTankBullet2;
    public bool isPlayerPowerUp1;
    public bool isPlayerPowerUp2;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void ChangeYDirection()
    {
        yDir *= -1;
    }

    private void Start()
    {
        Destroy(gameObject, 5);
    }


    // Update is called once per frame
    void Update () {
        if (isTankBullet1)
        {
            rb.velocity = new Vector2(5, -5);
        }
        else if (isTankBullet2)
        {
            rb.velocity = new Vector2(-5, -5);
        }
        else if (isPlayerPowerUp1)
        {
            rb.velocity = new Vector2(5, 10 * yDir);
        }
        else if (isPlayerPowerUp2)
        {
            rb.velocity = new Vector2(-5, 10 * yDir);
        }
        else
        {
            rb.velocity = new Vector2(0, 10 * yDir);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {   
        if (isTankBullet1 || isTankBullet2)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerBoat>().Damage();
                Destroy(gameObject);
            }
        }

        else if (yDir == 1)
        {
            if (col.gameObject.tag == "enemy")
            {
                col.gameObject.GetComponent<EnemyBoat>().Damage();
                Destroy(gameObject);
            }
        }

        else
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerBoat>().Damage();
                Destroy(gameObject);
            }
        }

    }
}
