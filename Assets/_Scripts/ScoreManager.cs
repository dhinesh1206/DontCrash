using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int score;
    public PathMove[] enemy;
    public float[] speed;
    public PathMove[] lookAt;
    public Text scoreText;
    public GameObject[] sideColliders;
    public PathMove[] players;
   
    void Start()
    {
        CheckScore();
    }

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        ScoreCount.ScoreAdded += Calculate;
        MainUiController.restartGame += RestartGame;
    }

    void OnDisable()
    {
        ScoreCount.ScoreAdded -= Calculate;
        MainUiController.restartGame -= RestartGame;
    }

    void Calculate()
    {
        score += 1;
        CheckScore();
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

    void CheckScore()
    {
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
            StartCoroutine(SetActiveCollider());
            foreach (var item in lookAt)
            {
                item.speedMultiplier = speed[0];
            }
        }
        else if (score == 6)
        {
            StartCoroutine(SetActiveCollider());
            foreach (PathMove item in players)
            {
                item.speedMultiplier = speed[1];
            }
            enemy[0].speedMultiplier = speed[1];
            lookAt[0].speedMultiplier = speed[1];
            StartCoroutine(SetSpeedBAck(2f, enemy[0], lookAt[0], speed[0]));
        }
        else if (score == 16)
        {
            StartCoroutine(SetActiveCollider());
            enemy[1].speedMultiplier = speed[2];
            lookAt[1].speedMultiplier = speed[2];
            StartCoroutine(SetSpeedBAck(2f, enemy[1], lookAt[1], speed[0]));
        }
    }

    IEnumerator SetActiveCollider(){
        yield return new WaitForSeconds(0.5f);
        if(score<5) {
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(false);
            sideColliders[2].SetActive(false);
        } else if(score == 16) {
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(true);
            sideColliders[2].SetActive(true);
        } else if(score == 6) {
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(true);
            sideColliders[2].SetActive(false);
        }
    }

    IEnumerator SetSpeedBAck(float timz, PathMove enem, PathMove lookat, float speeds)
    {
        yield return new WaitForSeconds(timz);
        enem.speedMultiplier = speeds;
        lookat.speedMultiplier = speeds;
    }
}
