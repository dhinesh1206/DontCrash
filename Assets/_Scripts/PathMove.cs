using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor
using System.Linq;

public class PathMove : MonoBehaviour 
{
	public static PathMove instance;
	public int Score;
	public bool enemy;
	public iTween.EaseType easeType;
	public List<Transform> waypoints;
	public List<PathList> NodePoints;
	public List<pathNames> paths;
    public float initialPathPercentange;
    public int PathIndex;
	public int Index = 0;
	public float PathPercent = 0;
	public float speedMultiplier;
    public Transform[] currentWavePoint;
	public Transform lookatObject;
    public bool PLaying;

    //public float speed;

	void Start () 
	{
        PLaying = false;
	}

	void Awake() {
		instance = this;
	}

    private void OnEnable()
    {
        MainUiController.GameStarted += StartGame;
        MainUiController.restartGame += StartGame;
    }

    private void OnDisable()
    {
        MainUiController.GameStarted -= StartGame;
        MainUiController.restartGame -= StartGame;
    }

    public void StartGame() {
        PLaying = true;
        PathPercent = initialPathPercentange;
        currentWavePoint = GetMyRoute(NodePoints[0].points);       
    }

    void Update() {
        if (PLaying) {
			PathPercent += speedMultiplier/10 * Time.deltaTime/currentWavePoint.Length;
			iTween.PutOnPath (gameObject, currentWavePoint, PathPercent);
			if(lookatObject)
			gameObject.transform.LookAt (lookatObject);
            if (PathPercent > 1) {
                if (gameObject.name == "EnemyCar1LookAT")
                    PathManager.instance.NextPathSelection();
               		PathPercent = 0;
					changelanes ();
			}
		}
	}

	
	//void movement(Transform[] wayPoints) 
	//{
    //    iTween.MoveTo (gameObject, iTween.Hash ("path", wayPoints, "speed", speed, "easetype", iTween.EaseType.linear,"oncomplete","changelanes", "orientToPath", true, "looktime",0.01f));
    //}

	void changelanes() {
        int index;
        if (enemy)
        {
            index = PathIndex;
        } else {
            index = 0;
        }
		string path = paths [0].nextPath [index];
		foreach (var objs in NodePoints) {
			if (path == objs.pathlistname) {
				currentWavePoint = GetMyRoute (objs.points);
			}
		}
	}

	public Transform[] GetMyRoute(List<int> list)
	{
		List<Transform> result = new List<Transform> ();
		foreach (int item in list) 
		{
			result.Add (waypoints[item]);
		}
		return result.ToArray ();
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
	
