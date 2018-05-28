using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents Instance;

    public delegate void ParameterlessDelegate();
    public event ParameterlessDelegate ScoreAdded, playerDied, GameStarted;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore()
    {
        if (ScoreAdded != null)
        {
            ScoreAdded();
        }

    }

    public void PlayerDie()
    {
        if (playerDied != null)
        {
            playerDied();
        }
    }

    public void StartGame()
    {
        if (GameStarted != null)
        {
            GameStarted();
        }
    }
}
