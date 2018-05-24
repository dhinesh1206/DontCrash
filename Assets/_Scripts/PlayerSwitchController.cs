using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class PlayerSwitchController : MonoBehaviour {

	public GameObject car1;
	public GameObject car2;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		EasyTouch.On_TouchStart += PlayerSwitch;
	}
    private void OnDisable()
    {
        EasyTouch.On_TouchStart -= PlayerSwitch;
    }

    // Update is called once per frame
    void Update () {
		
	}

	void PlayerSwitch(Gesture gesture) {
        BoxCollider[] colliders1 = car1.GetComponentsInChildren<BoxCollider>();
        foreach (var item in colliders1)
        {
            item.enabled = !item.enabled;
        }
        BoxCollider[] colliders2 = car2.GetComponentsInChildren<BoxCollider>();
        foreach (var item in colliders2)
        {
            item.enabled = !item.enabled;
        }
		car1.GetComponent<Renderer> ().enabled = !car1.GetComponent<Renderer> ().enabled;
		car2.GetComponent<Renderer> ().enabled = !car2.GetComponent<Renderer> ().enabled;
	}
}
