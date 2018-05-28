using UnityEngine;

public class MainUiController : MonoBehaviour
{
    public GameObject[] playerandEnemy;
    public GameObject playScreen, gameOverScreen, playingScreen;

    void OnEnable()
    {
        GameEvents.Instance.playerDied += GameOver;
    }

    void OnDisable()
    {
        GameEvents.Instance.playerDied -= GameOver;
    }

    public void GameOver()
    {

        foreach (GameObject item in playerandEnemy)
        {
            item.GetComponent<PathMove>().PLaying = false;
        }
        gameOverScreen.SetActive(true);
    }

    public void Gamestart()
    {
        playScreen.SetActive(false);
        playingScreen.SetActive(true);
        GameEvents.Instance.StartGame();
    }

    public void RestartGame()
    {
        playingScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        GameEvents.Instance.StartGame();
    }
}
