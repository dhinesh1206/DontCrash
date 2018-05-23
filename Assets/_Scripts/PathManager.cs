using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

	public static PathManager instance;
	public int pathIndex;
	// Use this for initialization
	void Start () {
		pathIndex = PathMove.instance.Index;
	}

	void Awake() {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreManager.instance.score < 5) {
				
		}
	}
}
