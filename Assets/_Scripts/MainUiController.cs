using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUiController : MonoBehaviour {
    
    public delegate void StartGame();
    public static event StartGame GameStarted;

    public delegate void Restart();
    public static event Restart restartGame;


    public GameObject[] playerandEnemy;
    public GameObject playScreen;
    public GameObject gameOverScreen;
    public GameObject playingScreen;

	void Start () {
		
	}
	
	void Update () {
		
	}
		
	void OnEnable() {
		ScoreCount.playerDied += GameOver;
	}

	void OnDisable() {
		ScoreCount.playerDied -= GameOver;
	}
		
	public void GameOver() {
        foreach (GameObject item in playerandEnemy)
        {
            item.GetComponent<PathMove>().PLaying = false;
        }
        gameOverScreen.SetActive(true);
	}

    public void Gamestart() {
        playScreen.SetActive(false);
        playingScreen.SetActive(true);
        if(GameStarted!= null){
            GameStarted();
        }
    }

    public void RestartGame() {
        playingScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        if(restartGame!= null) {
            restartGame();
        }
    }
}
