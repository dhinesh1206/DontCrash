using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents Instance;

    public delegate void ParameterlessDelegate();
    public event ParameterlessDelegate onScoreAdded, onPlayerDied, onGameStarted;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore()
    {
        if (onScoreAdded != null)
        {
            onScoreAdded();
        }
    }

    public void PlayerDie()
    {
        if (onPlayerDied != null)
        {
            onPlayerDied();
        }
    }

    public void StartGame()
    {
        if (onGameStarted != null)
        {
            onGameStarted();
        }
    }
}