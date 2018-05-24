using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
    public PathMove[] enemy;
    public float[] speed;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (score < 5)
        {
            foreach (PathMove item in enemy)
            {
                item.speedMultiplier = speed[0];
            }
        }
        else if (score > 5 && score < 16)
        {
            enemy[0].speedMultiplier = speed[1];
        }
        else if(score > 16)
        {
            enemy[2].speedMultiplier = speed[2];
        }
	}
}
