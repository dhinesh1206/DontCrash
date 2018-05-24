using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour {

	public delegate void ScoreEvent();
	public static event ScoreEvent ScoreAdded ;

	public delegate void PlayerDied ();
	public static event PlayerDied playerDied;
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
            if (collision.transform.gameObject.tag == "Enemy") 
            {
                if (playerDied != null) 
                {
                    playerDied ();
                }
            }  
        }
	}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "NearPoints")
        {
            if (ScoreAdded != null)
            {
                ScoreAdded();
            }
        }
        else if (collision.transform.gameObject.tag == "FinishPoint")
        {
            if (ScoreAdded != null)
            {
                ScoreAdded();
            }
        }
        else if (collision.transform.gameObject.tag == "SideCollider")
        {
            if (ScoreAdded != null)
            {
                print(collision.transform.parent.name);
                ScoreAdded();
            }
        }
    }
}
