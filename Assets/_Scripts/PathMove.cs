using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    public static PathMove instance;
    public iTween.EaseType easeType;
    public List<Transform> waypoints;
    public List<PathList> NodePoints;
    public List<PathNames> paths;
    public int pathIndex, score, index = 0;
    public float pathPercent = 0, speedMultiplier, initialPathPercentange;
    public Transform[] currentWavePoint;
    public Transform lookatObject;
    public bool playing, enemy;

    void Start()
    {
        playing = false;
    }

    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        GameEvents.Instance.onGameStarted += StartGame;
    }

    private void OnDisable()
    {
        GameEvents.Instance.onGameStarted -= StartGame;
    }

    public void StartGame()
    {
        playing = true;
        pathPercent = initialPathPercentange;
        currentWavePoint = GetMyRoute(NodePoints[0].points);
    }

    void Update()
    {
        if (playing)
        {
            pathPercent += speedMultiplier / 10 * Time.deltaTime / currentWavePoint.Length;
            iTween.PutOnPath(gameObject, currentWavePoint, pathPercent);
            if (lookatObject)
                gameObject.transform.LookAt(lookatObject);
            if (pathPercent > 1)
            {
                if (gameObject.name == "EnemyCar1LookAT")
                    PathManager.instance.NextPathSelection();
                pathPercent = 0;
                ChangeLanes();
            }
        }
    }

    void ChangeLanes()
    {
        if (enemy)
        {
            index = pathIndex;
        }
        else
        {
            index = 0;
        }
        string path = paths[0].nextPath[index];
        foreach (var objs in NodePoints)
        {
            if (path == objs.pathlistname)
            {
                currentWavePoint = GetMyRoute(objs.points);
            }
        }
    }

    public Transform[] GetMyRoute(List<int> list)
    {
        List<Transform> result = new List<Transform>();
        foreach (int item in list)
        {
            result.Add(waypoints[item]);
        }
        return result.ToArray();
    }

}