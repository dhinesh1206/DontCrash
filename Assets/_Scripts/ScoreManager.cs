using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int score;
    public Text scoreText;

   
    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        GameEvents.Instance.onScoreAdded += Calculate;
        GameEvents.Instance.onPlayerDied += UpdateHighScore;
        GameEvents.Instance.onGameStarted += RestartGame;
    }

    void OnDisable()
    {
        GameEvents.Instance.onScoreAdded -= Calculate;
        GameEvents.Instance.onPlayerDied -= UpdateHighScore;
        GameEvents.Instance.onGameStarted -= RestartGame;
    }

    public void UpdateHighScore()
    {
        //foreach (GameObject collide in ScoreEnemyColliders)
        //{
        //    collide.gameObject.GetComponent<BoxCollider>().enabled = false;
        //}
        int Highscore = PlayerPrefs.GetInt("HighScore");
        if (Highscore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void Calculate()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

}
