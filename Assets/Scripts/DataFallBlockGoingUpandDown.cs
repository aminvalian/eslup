
using UnityEngine;
using System.Collections;

public class DataFallBlockGoingUpandDown : MonoBehaviour {

	public Transform pointBPosition;
	[Range(0.1f,10f)]
	public float goUPSpeed;
	[Range(0.1f,10f)]
	public float goDownSpeed;
	[Range(0.1f,10f)]
	public float stopTime;
	//public Vector3 pointB;
	
	IEnumerator Start()

	{

		Vector3 pointA = transform.position;
		Vector3 pointB = pointBPosition.transform.position;

		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, goUPSpeed));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, goDownSpeed));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		float i= 0.0f;
		float rate= stopTime/time;
		while (i < stopTime) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

}
//using UnityEngine;
//using System.Collections;
//
//public class DataFallBlockGoingUpandDown : MonoBehaviour {
//		public float xDirectionLength = 1.0f;
//		public float yDirectionLength = 1.0f;
//
//		void Update() {
//			transform.position = new Vector3(Mathf.PingPong(Time.time, xDirectionLength), Mathf.PingPong(Time.time, yDirectionLength), transform.position.z);
//		}
//	}