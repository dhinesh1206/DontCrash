using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System.Linq;

public class PathMove : MonoBehaviour 
{
	public int speed;
	public iTween.EaseType easeType;
	public List<Transform> waypoints;
	//public List<PathList> routes;
	public List<PathList> NodePoints;
	static PathMove instance;
	public List<pathNames> paths;
	public int Index = 0;

	void Start () 
	{
		instance = this;
		foreach(var obj in NodePoints) {
			if (paths [Index].pathname == obj.pathlistname) {
				movement (GetMyRoute(obj.points));
			}
		}

	}
	
	void movement(Transform[] wayPoints) 
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", wayPoints, "speed", speed, "easetype", easeType, "oncomplete", "changelanes","oncompletetarget",gameObject, "orientToPath", true));
	}

	void changelanes() {
		int index = Random.Range (0,paths[Index].nextPath.Length);
		string path = paths [0].nextPath [index];
		print (path);
		foreach (var objs in NodePoints) {
			if (path == objs.pathlistname) {
				movement (GetMyRoute (objs.points));
			}
		}
//		int index = Random.Range(0,paths[Index].nextPath.Length);
//		string path = paths [Index].nextPath [index];
		//movement (GetMyRoute(path));
	}

	Transform[] GetMyRoute(List<int> list)
	{
		List<Transform> result = new List<Transform> ();
		foreach (int item in list) 
		{
			result.Add (waypoints[item]);
		}
		return result.ToArray ();
	}

//	[DrawGizmo(GizmoType.Active)]
//	static void DrawGameObjectName(Transform transform, GizmoType gizmoType)
//	{   
//		GUIStyle style = new GUIStyle(); 
//		style.normal.textColor = Color.red; 
//		style.fontSize = 100;
//		Handles.Label(transform.position, instance.waypoints.IndexOf(transform).ToString(),style);
//	}

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
	
