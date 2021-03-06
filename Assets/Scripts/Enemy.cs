﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	enum State{
		AttackPlayer,
		Drift
	}

	public GameObject deathWall;
	public float speed = .25f;

	State state = State.AttackPlayer;
	Vector3 target;

	int ticker;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform.position;
		InvokeRepeating("SecondUpdate", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {

		switch(state){
		case State.AttackPlayer:
			transform.position = Vector2.MoveTowards(transform.position, target, speed);
			//Debug.Log("ran at player");
			break;
		case State.Drift:
			transform.Translate(target);
			break;
		default:
			Debug.Log("Oh God!");
			break;
			
		}
	}

	void SecondUpdate(){
		switch(state){
		case State.AttackPlayer:
			//transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
			target = GameObject.FindGameObjectWithTag("Player").transform.position;
			//Debug.Log("Targeted player");
			break;
		case State.Drift:
			ticker -= 1;
			if(ticker<= 0){
				target = GameObject.FindGameObjectWithTag("Player").transform.position;
				state = State.AttackPlayer;
			}
			break;
		default:
			Debug.Log("Oh Dear God!");
			break;
		}
	}

	void bounce(Transform thing){
		Debug.Log("Hey bounce!!!");
	}


	void OnCollisionEnter2D(Collision2D other){
		switch(other.gameObject.tag){
		case "PlayerWall":
			Instantiate(deathWall, transform.position, Quaternion.identity);
			Destroy(gameObject);
			break;
		case "LevelWall":
		case "EnemyWall":
			bounce(other.transform);
			break;
		default:
			break;
		}
	}
}
