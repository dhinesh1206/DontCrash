using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceTest : MonoBehaviour {
	public List<GameObject> enemy;
	bool paused;
	public float minimumDistance;
	public float maximumDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkDistance (enemy[0],enemy[1]);
		checkDistance (enemy [1], enemy [2]);
	}

	void checkDistance(GameObject BeforePlayer, GameObject followingplayer) {
		
	}
}
