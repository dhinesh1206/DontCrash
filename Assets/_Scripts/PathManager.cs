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

    // Use this for initialization
    void Start () {
		pathIndex = PathMove.instance.Index;
        paths = PathMove.instance.paths;
	}

	void Awake() {
		instance = this;
	}

	void OnEnable() {
		ScoreCount.ScoreAdded += Calculate;
        ScoreCount.playerDied += UpdateHighScore;
        MainUiController.restartGame += RestartGame;
	}

	void OnDisable() {
		ScoreCount.ScoreAdded -= Calculate;
        ScoreCount.playerDied -= UpdateHighScore;
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


	// Update is called once per frame
	void Update () {
		if (ScoreManager.instance.score < 5) {
				
		}
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
			int index = Random.Range(0, paths[0].nextPath.Length);
			enemy [0].PathIndex = index;
			lookAt [0].PathIndex = index;
			int number = Random.Range(0, paths[0].nextPath.Length);
           	enemy[1].PathIndex = number;
			lookAt [1].PathIndex = number;
			lookAt [2].PathIndex = number;
            enemy[2].PathIndex = number;
        }
        else if (score > 16)
        {
			int index = Random.Range(0, paths[0].nextPath.Length);
			int index1 = Random.Range(0, paths[0].nextPath.Length);
			int index2 = Random.Range(0, paths[0].nextPath.Length);
			lookAt [0].PathIndex = index;
			lookAt [1].PathIndex = index1;
			lookAt [2].PathIndex = index2;
			enemy[0].PathIndex = index;
			enemy[1].PathIndex = index1;
			enemy[2].PathIndex = index2;
           
        }
    }

}
