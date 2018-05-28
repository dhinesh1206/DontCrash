using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour {

    public int score;
    public GameObject[] sideColliders;
    //public PathMove[] players;
    public GameObject[] frontCollider;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        GameEvents.Instance.ScoreAdded += Instance_ScoreAdded;
        GameEvents.Instance.GameStarted += Instance_GameStarted;
    }

    private void OnDisable()
    {
        GameEvents.Instance.ScoreAdded -= Instance_ScoreAdded;   
        GameEvents.Instance.GameStarted += Instance_GameStarted;
    }

    void Instance_ScoreAdded()
    {
        score += 1;
        ColliderCheck();
    }

    void Instance_GameStarted()
    {
        score = 0;
        ColliderCheck();
    }


    void ColliderCheck()
    {
        if (score < 5)
        {
            StartCoroutine(SetActiveCollider());
        }
        else if (score == 6)
        {
            StartCoroutine(SetActiveCollider());
        }
        else if (score == 16)
        {
            StartCoroutine(SetActiveCollider());
        }
    }


    IEnumerator SetActiveCollider()
    {
        yield return new WaitForSeconds(0.5f);
        if (score < 5)
        {
            sideColliders[0].SetActive(true);
            frontCollider[0].SetActive(true);
            sideColliders[1].SetActive(false);
            frontCollider[1].SetActive(false);
            sideColliders[2].SetActive(false);
            frontCollider[2].SetActive(false);
        }
        else if (score == 16)
        {
            frontCollider[0].SetActive(true);
            sideColliders[1].SetActive(true);
            frontCollider[2].SetActive(true);
            frontCollider[0].SetActive(true);
            sideColliders[1].SetActive(true);
            sideColliders[2].SetActive(true);
        }
        else if (score == 6)
        {
            frontCollider[0].SetActive(true);
            frontCollider[1].SetActive(true);
            frontCollider[2].SetActive(false);
            sideColliders[0].SetActive(true);
            sideColliders[1].SetActive(true);
            sideColliders[2].SetActive(false);
        }
    }


}
