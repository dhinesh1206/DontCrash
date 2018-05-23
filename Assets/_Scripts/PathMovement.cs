using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour {

	public List<Paths> paths;
	public float speed;
	public string path;
	public iTween.EaseType easeType;
	public int Index;
	public bool enemy;
	public float PathPercent = 0;
	public float speedMultiplier;
	bool pathSwitched;
	// Use this for initialization
	void Start () {
		if (!enemy)
			movement (paths [0].pathName);
		pathSwitched = false;
		Index = 0;
	}

	void Update () {
		if (enemy) {
			PathPercent += speedMultiplier/10 * Time.deltaTime;
			iTween.PutOnPath (gameObject, iTweenPath.GetPath (path), PathPercent);
			if (PathPercent > 0.95) {
				if (!pathSwitched) {
					pathSwitched = true;
					movement (paths [Index].nextPath [Random.Range (0, paths [Index].nextPath.Length)]);
				}
			}
		}
	}

	void movement(string pathName) {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (pathName), "speed", speed, "easetype", easeType, "oncomplete", "changelanes","oncompletetarget",gameObject, "orientToPath", true));
	}

	public void changelanes() 
	{
		int index = Random.Range (0,paths[Index].nextPath.Length);
		string path = paths [Index].nextPath [index];
		foreach(var obj in paths) {
			if(obj.pathName == path) {
				Index = paths.IndexOf (obj);
				movement (path);
			}
		}

	}
}

[System.Serializable]
public class Paths {
	public string pathName;
	public string[] nextPath;
}
