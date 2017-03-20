using UnityEngine;
using System.Collections;

public class ScrollMainMenuBack : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position= new Vector2(transform.position.x, transform.position.y+speed);
		if (transform.position.y > 500){
			transform.position = new Vector2(transform.position.x, transform.position.y -956);
		}
	}
}
