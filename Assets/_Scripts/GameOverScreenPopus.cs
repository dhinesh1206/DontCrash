using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenPopus : MonoBehaviour
{

    public GameObject[] buttons;
    public float time, delay;
    public iTween.EaseType easeType;
    public Text bestScoreText;

    void OnEnable()
    {
        foreach (GameObject button in buttons)
        {
            button.transform.localScale = Vector3.zero;
        }
        StartCoroutine(Animatepopup());
    }

    void Update()
    {
        bestScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public IEnumerator Animatepopup()
    {
        foreach (GameObject button in buttons)
        {
            iTween.ScaleTo(button, iTween.Hash("scale", Vector3.one, "easetype", easeType, "time", time, "delay", delay));
            yield return new WaitForSeconds(time + delay);
        }
    }
}
