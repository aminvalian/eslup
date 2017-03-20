using UnityEngine;
using System.Collections;

public class ScrollBackGroundLevelDos : MonoBehaviour {
	public float speed = 0.05f;
	private float nextActionTime = 0.0f;
	public float period = 0.1f;
	
	void Update () {
		Vector2 offset = new Vector2 (0, Time.time * speed);
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			GetComponent<Renderer> ().material.mainTextureOffset = offset;
		}
	}
}
