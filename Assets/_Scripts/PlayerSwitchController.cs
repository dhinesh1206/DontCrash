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
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayerSwitch(Gesture gesture) {
		car1.GetComponent<BoxCollider> ().enabled = !car1.GetComponent<BoxCollider> ().enabled;
		car2.GetComponent<BoxCollider> ().enabled = !car2.GetComponent<BoxCollider> ().enabled;
		car1.GetComponent<Renderer> ().enabled = !car1.GetComponent<Renderer> ().enabled;
		car2.GetComponent<Renderer> ().enabled = !car2.GetComponent<Renderer> ().enabled;
	}
}
