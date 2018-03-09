using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    private Rigidbody2D rb;
    public float scrollSpeed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -scrollSpeed);
	}

}
