using UnityEngine;
using System.Collections;

public class OPulseScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0 , -2);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5f){
			Destroy(this.gameObject,2f);
		}
	}
}
