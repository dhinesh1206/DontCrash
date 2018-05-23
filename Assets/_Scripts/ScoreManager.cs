using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
