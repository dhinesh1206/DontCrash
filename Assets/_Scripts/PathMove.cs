using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    public static PathMove instance;
    public iTween.EaseType easeType;
    public List<Transform> waypoints;
    public List<PathList> NodePoints;
    public List<pathNames> paths;
    public int PathIndex, Score, Index = 0;
    public float PathPercent = 0, speedMultiplier, initialPathPercentange;
    public Transform[] currentWavePoint;
    public Transform lookatObject;
    public bool PLaying, enemy;

    void Start()
    {
        PLaying = false;
    }

    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        GameEvents.Instance.GameStarted += StartGame;
    }

    private void OnDisable()
    {
        GameEvents.Instance.GameStarted -= StartGame;
    }

    public void StartGame()
    {
        PLaying = true;
        PathPercent = initialPathPercentange;
        currentWavePoint = GetMyRoute(NodePoints[0].points);
    }

    void Update()
    {
        if (PLaying)
        {
            PathPercent += speedMultiplier / 10 * Time.deltaTime / currentWavePoint.Length;
            iTween.PutOnPath(gameObject, currentWavePoint, PathPercent);
            if (lookatObject)
                gameObject.transform.LookAt(lookatObject);
            if (PathPercent > 1)
            {
                if (gameObject.name == "EnemyCar1LookAT")
                    PathManager.instance.NextPathSelection();
                PathPercent = 0;
                changelanes();
            }
        }
    }

    void changelanes()
    {
        int index;
        if (enemy)
        {
            index = PathIndex;
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

[System.Serializable]
public class PathList
{
    public string pathlistname;
    public List<int> points;
}

[System.Serializable]
public class pathNames
{
    public string pathname;
    public string[] nextPath;
}