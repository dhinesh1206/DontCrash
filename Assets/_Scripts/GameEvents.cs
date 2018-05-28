using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

    public static GameEvents instance;

    public delegate void ScoreEvent();
    public static event ScoreEvent ScoreAdded;


    public delegate void PlayerDied();
    public static event PlayerDied playerDied;

    private void Awake()
    {
        instance = this;
    }

    public void IncrementScore() 
    {
        if(ScoreAdded != null)
        {
            ScoreAdded();
        }
       
    }

    public void PlayerDie() {
        if(playerDied!=null) {
            playerDied();
        }
    }
}
