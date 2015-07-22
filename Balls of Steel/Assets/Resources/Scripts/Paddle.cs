using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

	Transform myTransform;
	public float xLimit;
	public float ballRandomAngle;

	public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
		myTransform = transform;	
	}
	
	// Update is called once per frame
	void Update () {
		float delta = Input.GetAxis ("Horizontal");
		myTransform.position += new Vector3 (delta, 0, 0);
		if (Math.Abs(myTransform.position.x) > xLimit) {
			myTransform.position = new Vector3(Math.Sign(myTransform.position.x)  * xLimit, myTransform.position.y, myTransform.position.z);
		}

		if (Input.GetMouseButtonUp (0)) {
			GameManager.instance().tryLaunchBall();
		}
	}
}
