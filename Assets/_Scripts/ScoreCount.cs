using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour {

	//public delegate void ScoreEvent();
	//public static event ScoreEvent ScoreAdded ;

	
    public bool godMode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

	void OnCollisionEnter(Collision collision) 
    {
        if (!godMode)
        {

            if (collision.transform.gameObject.tag == "NearEnemy")
            {
                GameEvents.instance.IncrementScore();
            }
            else if (collision.transform.gameObject.tag == "Enemy") 
            {
                GameEvents.instance.PlayerDie();
            }  
        }
	}

    private void OnCollisionExit(Collision collision)
    {
         if (collision.transform.gameObject.tag == "FinishPoint")
        {
            GameEvents.instance.IncrementScore();
        }
        else if (collision.transform.gameObject.tag == "SideCollider")
        {
            GameEvents.instance.IncrementScore();
        }
    }
}
