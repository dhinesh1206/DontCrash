using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
    public PathMove[] enemy;
    public float[] speed;
	public PathMove[] lookAt;
    public Text scoreText;
    public GameObject[] sideColliders;
    public PathMove[] players;
	// Use this for initialization
	void Start () {
		CheckScore ();
	}

	void Awake() {
		instance = this;
	}

	void OnEnable() {
		ScoreCount.ScoreAdded += Calculate;
        MainUiController.restartGame += RestartGame;
	}

	void OnDisable() {
		ScoreCount.ScoreAdded -= Calculate;
        MainUiController.restartGame -= RestartGame;
	}

	void Calculate() {
		score += 1;
		CheckScore ();
	}

    void RestartGame()
    {
        score = 0;
        CheckScore();
    }


    private void Update()
    {
        scoreText.text = score.ToString();
    }

    void CheckScore () {
        if (score < 5)
        {
            foreach (PathMove item in players)
            {
                item.speedMultiplier = speed[0];
            }
            foreach (PathMove item in enemy)
            {
                item.speedMultiplier = speed[0];
            }
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(false);
            sideColliders[2].SetActive(false);
			foreach (var item in lookAt) {
				item.speedMultiplier = speed [0];
			}
        } else if (score == 6)
        {
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(true);
            sideColliders[2].SetActive(false);
        }
        else if (score > 5 && score < 16)
        {
            foreach (PathMove item in players)
            {
                item.speedMultiplier = speed[1];
            }
           
			lookAt [0].speedMultiplier = speed [1];
            enemy[0].speedMultiplier = speed[1];
        }
        else if(score > 16)
        {
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(true);
            sideColliders[2].SetActive(true);
			lookAt [2].speedMultiplier = speed [2];
            enemy[2].speedMultiplier = speed[2];
        }
	}


}
