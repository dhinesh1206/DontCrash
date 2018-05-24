using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceTest : MonoBehaviour {
	public List<GameObject> enemy;
	bool paused;
	public float minimumDistance;
	public float maximumDistance;
	public float[] FirstDistance;
	public float[] SecontDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkDistance (enemy[0],enemy[1], FirstDistance);
		checkDistance (enemy [1], enemy [2], SecontDistance);
	}

	void checkDistance(GameObject BeforePlayer, GameObject followingplayer, float[] Distance) {
		if (Vector3.Distance (enemy [0].transform.position, enemy [1].transform.position )> Distance [0]) {
		//	followingplayer.GetComponent<PathMove>().
		}
	}
}
