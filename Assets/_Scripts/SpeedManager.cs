using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {
    public PathMove[] players;
    public PathMove[] lookAt;
    public PathMove[] enemy;
    public float[] speed;
    public int score;
	// Use this for initialization
    void Start()
    {
        SpeedCheck();
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        GameEvents.Instance.onScoreAdded += Calculate;
        GameEvents.Instance.onGameStarted += RestartGame;
    }

    void OnDisable()
    {
        GameEvents.Instance.onScoreAdded -= Calculate;
        GameEvents.Instance.onGameStarted -= RestartGame;
    }

    void Calculate()
    {
        score += 1;
        SpeedCheck();
    }

    void RestartGame()
    {
        score = 0;
        SpeedCheck();
    }

    void SpeedCheck()
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
            // StartCoroutine(SetActiveCollider());
            foreach (var item in lookAt)
            {
                item.speedMultiplier = speed[0];
            }
        }
        else if (score == 6)
        {
            //StartCoroutine(SetActiveCollider());
            foreach (PathMove item in players)
            {
                item.speedMultiplier = speed[1];
            }
            enemy[0].speedMultiplier = speed[1];
            lookAt[0].speedMultiplier = speed[1];
            StartCoroutine(SetSpeedBack(2f, enemy[0], lookAt[0], speed[0]));
        }
        else if (score == 16)
        {
            //StartCoroutine(SetActiveCollider());
            enemy[1].speedMultiplier = speed[2];
            lookAt[1].speedMultiplier = speed[2];
            StartCoroutine(SetSpeedBack(2f, enemy[1], lookAt[1], speed[0]));
        }
    }



    IEnumerator SetSpeedBack(float timz, PathMove enem, PathMove lookat, float speeds)
    {
        yield return new WaitForSeconds(timz);
        enem.speedMultiplier = speeds;
        lookat.speedMultiplier = speeds;
    }
}
