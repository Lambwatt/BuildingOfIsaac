using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float fullTime;
    public Text timerText;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        countDown();
	}

    void countDown()
    {
        fullTime -= Time.deltaTime;
        if (fullTime == 0)
        {
            SceneManager.LoadScene("gameOver");
        }
    }


    void loadGameScene()
    {
        SceneManager.LoadScene("main");
    }
}
