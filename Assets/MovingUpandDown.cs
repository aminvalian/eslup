using UnityEngine;
using System.Collections;

public class MovingUpandDown : MonoBehaviour {

	public float passedTime = 0.0f;
	public float tikTak = 0.5f;
	public float moveAmount = .05f;
	public float loop = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		passedTime += Time.deltaTime;
		if (transform.position.y >= loop) {
			transform.position = new Vector2 (transform.position.x, 2.0f);
		}

		if (passedTime >= tikTak) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + moveAmount);
			passedTime = 0.0f;
		}

	}
}
