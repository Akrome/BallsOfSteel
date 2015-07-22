using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {
	// Audio
	public AudioClip bounceSound;
	public float bounceSoundVolume;

	//Game
	public float minYSpeed;

	Transform myTransform;
	Rigidbody myRigidBody;

	float verticalLimit = 15;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		myRigidBody = GetComponent<Rigidbody> ();
		myRigidBody.velocity = myTransform.up * minYSpeed / myTransform.up.y;
	}

	void FixedUpdate () {
		if (Math.Abs (myTransform.position.y) > verticalLimit) {
			GameManager.instance().destroyBall();
			Destroy (gameObject);
		} 
		else {
			Vector3 velocity = myRigidBody.velocity;
			if (Math.Abs (velocity.y) < minYSpeed) {
				velocity.y = minYSpeed * Math.Sign (velocity.y);
				myRigidBody.velocity = velocity;
			}
		}

	}

	void OnCollisionEnter(Collision c) {
		AudioSource.PlayClipAtPoint (bounceSound, myTransform.position, bounceSoundVolume);
	}
}
