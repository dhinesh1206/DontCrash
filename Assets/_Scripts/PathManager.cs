using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public static PathManager instance;
    public int pathIndex, score;
    public PathMove[] enemy;
    public List<PathNames> paths;
    public PathMove[] lookAt;
    public GameObject[] ScoreEnemyColliders;

    void Start()
    {
        pathIndex = PathMove.instance.index;
        paths = PathMove.instance.paths;
    }

    void Awake()
    {
        instance = this;
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
                item.pathIndex = number;
            }
            foreach (var item in lookAt)
            {
                item.pathIndex = number;
            }
        }
        else if (score > 5 && score < 16)
        {
            int index = Random.Range(1, paths[0].nextPath.Length);
            enemy[0].pathIndex = index;
            lookAt[0].pathIndex = index;

            int number = index - 1;
            enemy[1].pathIndex = number;
            lookAt[1].pathIndex = number;
            lookAt[2].pathIndex = number;
            enemy[2].pathIndex = number;
        }
        else if (score > 16)
        {
            int index = Random.Range(2, paths[0].nextPath.Length);
            lookAt[0].pathIndex = index;
            lookAt[1].pathIndex = index - 1;
            lookAt[2].pathIndex = index - 2;
            enemy[0].pathIndex = index;
            enemy[1].pathIndex = index - 1;
            enemy[2].pathIndex = index - 2;

        }
    }
}
