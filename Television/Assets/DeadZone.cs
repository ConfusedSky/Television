using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Failure))]
public class DeadZone : MonoBehaviour {

	GameObject player;
	Failure failure;
	public float deadzone = -20f;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		failure = gameObject.GetComponent<Failure> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.transform.position.y <= deadzone)
		{
			failure.FailImmediate ();
		}
	}
}
