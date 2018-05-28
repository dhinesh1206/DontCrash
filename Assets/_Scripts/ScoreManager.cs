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
        GameEvents.Instance.ScoreAdded += Calculate;
        GameEvents.Instance.playerDied += UpdateHighScore;
        GameEvents.Instance.GameStarted += RestartGame;
    }

    void OnDisable()
    {
        GameEvents.Instance.ScoreAdded -= Calculate;
        GameEvents.Instance.playerDied -= UpdateHighScore;
        GameEvents.Instance.GameStarted -= RestartGame;
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
    }

    void RestartGame()
    {
        score = 0;
    }


    private void Update()
    {
        scoreText.text = score.ToString();
    }

}
