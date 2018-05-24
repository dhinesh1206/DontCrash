using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor
using System.Linq;

public class PathMove : MonoBehaviour 
{
	public static PathMove instance;
	public float speed;
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
	public bool pathSwitched;
	public Transform[] tempWavepoints;
	public Transform lookatObject;
    public bool PLaying;


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
        MainUiController.restartGame += RestartGame;
    }

    private void OnDisable()
    {
        MainUiController.GameStarted -= StartGame;
        MainUiController.restartGame -= RestartGame;
    }

    public void StartGame() {
        PLaying = true;
        PathPercent = initialPathPercentange;
        tempWavepoints = GetMyRoute(NodePoints[0].points);
       
    }

    public void RestartGame() {
        PLaying = true;
        PathPercent = initialPathPercentange;
        tempWavepoints = GetMyRoute(NodePoints[0].points);
    }

    void Update() {
        if (PLaying) {
			PathPercent += speedMultiplier/10 * Time.deltaTime/tempWavepoints.Length;
			iTween.PutOnPath (gameObject, tempWavepoints, PathPercent);
			if(lookatObject)
			gameObject.transform.LookAt (lookatObject);
            if (PathPercent > 1) {
				if (gameObject.name == "Ene1")
                    PathManager.instance.NextPathSelection();
               		PathPercent = 0;
					changelanes ();
			}
		}
	}
	
	void movement(Transform[] wayPoints) 
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", wayPoints, "speed", speed, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop,"oncompletetarget",gameObject, "orientToPath", true, "looktime",0.01f));
	}

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
				tempWavepoints = GetMyRoute (objs.points);
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
	
