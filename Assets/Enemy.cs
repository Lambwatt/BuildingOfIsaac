using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	enum State{
		AttackPlayer,
		Drift
	}

	State state = State.AttackPlayer;
	Vector3 target;
	float speed;
	int ticker;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform.position;
		InvokeRepeating();
	}
	
	// Update is called once per frame
	void Update () {

		switch(state){
		case State.AttackPlayer:
			transform.position = Vector2.MoveTowards(transform.position, target, speed);
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

	void OnCollisionEnter2D(Collider2D other){
		switch(other.tag){
		case "PlayerWall":
		case "LevelWall":
		case "EnemyWall":
		default:
			break;
		}
	}
}
