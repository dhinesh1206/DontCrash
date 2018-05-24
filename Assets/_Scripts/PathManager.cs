using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

	public static PathManager instance;
	public int pathIndex;
    public int score;
    public PathMove[] enemy;
    public List<pathNames> paths;

    // Use this for initialization
    void Start () {
		pathIndex = PathMove.instance.Index;
        paths = PathMove.instance.paths;
	}

	void Awake() {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreManager.instance.score < 5) {
				
		}
	}

    public void NextPathSelection()
    {
        if (score < 5)
        {
            int number = Random.RandomRange(0, paths[0].nextPath.Length);
            foreach (PathMove item in enemy)
            {
                item.PathIndex = number;
            }
        }
        else if (score > 5 && score < 16)
        {
            enemy[0].PathIndex = Random.RandomRange(0, paths[0].nextPath.Length);
            int number = Random.RandomRange(0, paths[0].nextPath.Length);
            enemy[1].PathIndex = number;
            enemy[2].PathIndex = number;
        }
        else if (score > 16)
        {
            enemy[0].PathIndex = Random.RandomRange(0, paths[0].nextPath.Length);
            enemy[1].PathIndex = Random.RandomRange(0, paths[0].nextPath.Length);
            enemy[2].PathIndex = Random.RandomRange(0, paths[0].nextPath.Length);
        }
    }

}
