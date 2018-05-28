using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public bool godMode;

    void OnCollisionEnter(Collision collision)
    {
        if (!godMode)
        {

            if (collision.transform.gameObject.tag == "NearEnemy")
            {
                GameEvents.Instance.IncrementScore();
            }
            else if (collision.transform.gameObject.tag == "Enemy")
            {
                GameEvents.Instance.PlayerDie();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "FinishPoint")
        {
            GameEvents.Instance.IncrementScore();
        }
        else if (collision.transform.gameObject.tag == "SideCollider")
        {
            GameEvents.Instance.IncrementScore();
        }
    }
}
