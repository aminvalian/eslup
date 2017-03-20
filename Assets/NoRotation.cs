using UnityEngine;
using System.Collections;

public class NoRotation : MonoBehaviour {
	public Quaternion originalRotation;
	// Use this for initialization
	void Start () {
		originalRotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = originalRotation;
	
	}
}
