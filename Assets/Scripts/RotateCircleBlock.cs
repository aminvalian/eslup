using UnityEngine;
using System.Collections;

public class RotateCircleBlock : MonoBehaviour {
	public float rotationSpeed = 15.0f;
	public Transform centerTransform;
	private Vector2 centerPosition;
	public float xPostion = 0;
	public float yPostion = 0;
	// Use this for initialization
	void Start () {
		centerPosition = centerTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		centerPosition = centerTransform.position;
		transform.RotateAround(Vector3.zero, Vector3.back, rotationSpeed * Time.deltaTime); // vectore3.forward 
		transform.position = new Vector2 (centerPosition.x, centerPosition.y);

	}
}
