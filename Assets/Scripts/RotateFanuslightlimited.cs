using UnityEngine;
using System.Collections;

public class RotateFanuslightlimited : MonoBehaviour {

	public float maxdaraje;
	public float mindaraje;
	public float speedRotation = 1;

	private float currentdaraje;
	private float i = 1;

		

		void Update(){


		currentdaraje = Mathf.Round (transform.eulerAngles.z);
		if (currentdaraje == maxdaraje) {
			i=-i;
		}
		if (currentdaraje == mindaraje) {
			i=-i;
		}

		transform.Rotate (new Vector3 (0, 0, i*speedRotation));
	}
}
//			if (Mathf.Round (transform.eulerAngles.z) < 1.0f) {
//			transform.Rotate (new Vector3 (0, 0, 1));

//		}
//	public void becharkhun()
//	{
//		if (currentdaraje > mindaraje & currentdaraje < maxdaraje)
//
//		{
//			currentdaraje ++ ;
//
//
//		}
//	}


















//
//	void Start()
//	{
//
//	}
//	void Update(){
//
//		if (Mathf.Round (transform.eulerAngles.z) < 1.0f) {
//			transform.Rotate (new Vector3 (0, 0, 1));
//		} else if (Mathf.Round (transform.eulerAngles.z) > 40.0f) {
//			transform.Rotate (new Vector3 (0, 0, -1));
//		}
//	}
//}
////		esle 
//	
//			transform.Rotate(new Vector3(0,0,-1));


//		transform.Rotate(new Vector3(0,0,1));
//		while(Mathf.Round(transform.eulerAngles.z)< 180.0f) 
////			transform.Rotate(new Vector3(0,0,-1)); 
//	}
//}

//
//	void moveAround()
//	{
//		float i = 0.0f;
//		while (i < 15)
//		{
//			i++;
//			transform.Rotate(0,0,5);
//		}
//		transform.Rotate(0,0,-i);
//		i--;
//	}
////	public float dir = .5f;
////
////	void update()
////	{
////		transform.Rotate(Vector3.forward * Time.deltaTime, Space.World);	}
////
////	public Transform rotateAroundPosition;
////	public float speedRotation = 5;
////
////
////	public Transform pointBPosition;
////	[Range(0.1f,10f)]
////	public float goUPSpeed;
////	[Range(0.1f,10f)]
////	public float goDownSpeed;
////	[Range(0.1f,10f)]
////	public float stopTime;
////	//public Vector3 pointB;
////	
////	IEnumerator Start()
////		
////	{
////		
////		Vector3 pointA = transform.position;
////		Vector3 pointB = pointBPosition.transform.position;
////		
////		while (true) {
////			yield return StartCoroutine(MoveObject(transform, pointA, pointB, goUPSpeed));
////			yield return StartCoroutine(MoveObject(transform, pointB, pointA, goDownSpeed));
////		}
////	}
////	
////	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
////	{
////		float i= 0.0f;
////		float rate= stopTime/time;
////		while (i < stopTime) {
////			i += Time.deltaTime * rate;
////			transform.RotateAround (rotateAroundPosition.position, Vector3.forward, i);
//////			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
////			yield return null; 
////		}
////	}
////
////
////
////
////
////
////
////
////
////
////
////
////
////
////
////
//
//
////	public float rotSpeed;
////
////	void Awake()
////	{
////		StartCoroutine (LoopRotation (30f));
////	}
////	IEnumerator LoopRotation(float angle)
////	{
////		float rot = 0f;
////		float dir = 1f;
////		while(true)
////		{
////			while(rot < angle)
////			{
////				float step = Time.deltaTime * rotSpeed;
////				transform.Rotate(new Vector3(0,0,12)*step * dir);
////				yield return null;
////			}
////			rot= 0f;
////			dir *= -1f;
////		}
////	}
//	
//
//}
