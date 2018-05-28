using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

	public static PathManager instance;
	public int pathIndex;
    public int score;
    public PathMove[] enemy;
    public List<pathNames> paths;
	public PathMove[] lookAt;
    public GameObject[] ScoreEnemyColliders;
   
    void Start () {
		pathIndex = PathMove.instance.Index;
        paths = PathMove.instance.paths;

	}

	void Awake() {
		instance = this;
	}

	void OnEnable() {
        GameEvents.ScoreAdded += Calculate;
        GameEvents.playerDied += UpdateHighScore;
        MainUiController.restartGame += RestartGame;
	}

	void OnDisable() {
        GameEvents.ScoreAdded -= Calculate;
        GameEvents.playerDied -= UpdateHighScore;
	}

	void Calculate() {
		score += 1;
	}

    public void UpdateHighScore() {
        foreach(GameObject collide in ScoreEnemyColliders) {
            collide.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        int Highscore = PlayerPrefs.GetInt("HighScore");
        if (Highscore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void RestartGame()
    {
        foreach (GameObject collide in ScoreEnemyColliders)
        {
            collide.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        score = 0;
        pathIndex = 0;
    }

    public void NextPathSelection()
    {
        if (score < 5)
        {
			int number = Random.Range(0, paths[0].nextPath.Length);
            foreach (PathMove item in enemy)
            {
                item.PathIndex = number;
            }
			foreach (var item in lookAt) {
				item.PathIndex = number;
			}
        }
        else if (score > 5 && score < 16)
        {
			int index = Random.Range(1, paths[0].nextPath.Length);
			enemy [0].PathIndex = index;
			lookAt [0].PathIndex = index;

            int number = index-1;
           	enemy[1].PathIndex = number;
			lookAt [1].PathIndex = number;
			lookAt [2].PathIndex = number;
            enemy[2].PathIndex = number;
        }
        else if (score > 16)
        {
            int index = Random.Range(2, paths[0].nextPath.Length);
			lookAt [0].PathIndex = index;
            lookAt [1].PathIndex = index-1;
            lookAt [2].PathIndex = index-2;
			enemy[0].PathIndex = index;
            enemy[1].PathIndex = index - 1;
            enemy[2].PathIndex = index - 2;
           
        }
    }

}
