﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    
    public float rateOfFire;
    public GameObject playerWall;

    private float lastShotTime = 0;
    private AudioSource audioSource;

    private float wallOffset = 0.75f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        handleControls();
        handleBuild();
    }

    void handleControls()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed);
        }
    }

    void handleBuild()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (lastShotTime == 0 ||Time.time > lastShotTime + rateOfFire)
            {
                Instantiate(playerWall, new Vector2(transform.position.x, transform.position.y + wallOffset), Quaternion.Euler(0, 0, 90));
                lastShotTime = Time.time;
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Time.time > lastShotTime + rateOfFire)
            {
                Instantiate(playerWall, new Vector2(transform.position.x, transform.position.y - wallOffset), Quaternion.Euler(0, 0, 90));
                lastShotTime = Time.time;
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time > lastShotTime + rateOfFire)
            {
                Instantiate(playerWall, new Vector2(transform.position.x - wallOffset, transform.position.y), Quaternion.identity);
                lastShotTime = Time.time;
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time > lastShotTime + rateOfFire)
            {
                Instantiate(playerWall, new Vector2(transform.position.x + wallOffset, transform.position.y), Quaternion.identity);
                lastShotTime = Time.time;
                audioSource.Play();
            }
        }
    }
}
