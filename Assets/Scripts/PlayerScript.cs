using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public GameObject playerWall;

    private float wallOffset = 0.75f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
            Instantiate(playerWall, new Vector2(transform.position.x, transform.position.y + wallOffset), Quaternion.Euler(0, 0, 90));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(playerWall, new Vector2(transform.position.x, transform.position.y - wallOffset), Quaternion.Euler(0, 0, 90));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(playerWall, new Vector2(transform.position.x - wallOffset, transform.position.y), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(playerWall, new Vector2(transform.position.x + wallOffset, transform.position.y), Quaternion.identity);
        }
    }
    
}
