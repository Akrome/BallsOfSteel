using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int points;
	public float verticalSpeed;
	public float yLimit;

	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}

	void Update() {
		if (myTransform.position.y < yLimit) {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		myTransform.position -= Vector3.up * Time.deltaTime * verticalSpeed;
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.tag == "Ball") {
			Destroy (gameObject);
		}
	}
}
