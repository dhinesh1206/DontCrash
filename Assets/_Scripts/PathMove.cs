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
	public int Index = 0;
	public float PathPercent = 0;
	public float speedMultiplier;
	public bool pathSwitched;
	public Transform[] tempWavepoints;

	public GameObject enemylookAT;

	void Start () 
	{
		if (enemy)
			tempWavepoints = GetMyRoute (NodePoints[0].points);
			
		else {
			foreach (var obj in NodePoints) {
				if (paths [Index].pathname == obj.pathlistname) {
					movement (GetMyRoute (obj.points));
				}
			}
		}

	}

	void Awake() {
		instance = this;
	}

	void Update() {
		
		if (enemy) {
			PathPercent += speedMultiplier/10 * Time.deltaTime/tempWavepoints.Length;
			iTween.PutOnPath (gameObject, tempWavepoints, PathPercent);
			Vector3 tempPosition = iTween.PointOnPath (tempWavepoints,PathPercent+speedMultiplier/10 * Time.deltaTime);
			enemylookAT.transform.position = tempPosition;
			gameObject.transform.LookAt (enemylookAT.transform);
			if (PathPercent > 1) {
					PathPercent = 0;
					changelanes ();
			}
		}
	}
	
	void movement(Transform[] wayPoints) 
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", wayPoints, "speed", speed, "easetype", iTween.EaseType.linear, "oncomplete", "changelanes","oncompletetarget",gameObject, "orientToPath", true, "looktime",0.01f));
	}

	void changelanes() {
		int index = Random.Range (0,paths[Index].nextPath.Length);
		string path = paths [0].nextPath [index];
		print (path);
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
	
