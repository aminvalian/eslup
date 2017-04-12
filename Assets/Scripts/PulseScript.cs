using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0 , 2);
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}

}
