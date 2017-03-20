using UnityEngine;
using System.Collections;

public class ScrollBackGround : MonoBehaviour {

	public float speed = 0.05f;
	public float waitTime = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
//	 Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
//	void Update () {
//		ScrollStopAndGo ();
//	}
//
//	IEnumerator ScrollStopAndGo()
//	{
//		float offset = Time.time * speed;
//		yield return new WaitForSeconds(waitTime);
//		GetComponent<Renderer> ().material.mainTextureOffset =  new Vector2(0, offset+ .1f);
//	}

}
