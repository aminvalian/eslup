using UnityEngine;
using System.Collections;

public class MovinganObjectAround : MonoBehaviour {

	public float speed = 25;

	public Vector3 point;

	void Start()
	{

	}



	void Update() {
		transform.RotateAround(point, Vector3.forward, speed * Time.deltaTime);
	}
}
//
//	public float smooth = 2.0F;
//	public float tiltAngle = 30.0F;
//	void Update() {
//		float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
//		float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
//		Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
//		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
//	}
//}
