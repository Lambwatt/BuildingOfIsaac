using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		InvokeRepeating("spawn", 1f, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawn(){

		Instantiate(enemy, transform.position+new Vector3(Random.Range(0f,2f), Random.Range(0f,2f)), Quaternion.identity);
	}
}
