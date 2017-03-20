using UnityEngine;
using System.Collections;

public class RotateFanuslight : MonoBehaviour {
	public Transform rotateAroundPosition;
	public float speedRotation = 5;
//	public Vector3 rotateAroundPosition;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (rotateAroundPosition.position, Vector3.forward, Time.deltaTime * speedRotation);
		                
	}
}
