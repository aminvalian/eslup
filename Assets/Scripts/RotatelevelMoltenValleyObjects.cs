using UnityEngine;
using System.Collections;

public class RotatelevelMoltenValleyObjects : MonoBehaviour {
	public GameObject positionBlock;
	public float xPluse;
	public float yPluse;
	 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (positionBlock.transform.position.x + xPluse, positionBlock.transform.position.y + yPluse);
//		(new Vector3 (0, 0, Time.deltaTime * speedRotation));
//		transform.position(new Vector3(transorm.position.x,1
	}
}
