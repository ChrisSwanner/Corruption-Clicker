using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public float rate;
    public GameObject[] enemies;
    public int waves = 1;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", rate, rate);
	}
	
	// Update is called once per frame
	void SpawnEnemy () {
		for(int i=0; i<waves; i++)
        {
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8f, 8f), 8f, 0f),Quaternion.identity);
        }
	}
}
