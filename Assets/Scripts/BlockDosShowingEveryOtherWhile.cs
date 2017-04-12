using UnityEngine;
using System.Collections;

public class BlockDosShowingEveryOtherWhile : MonoBehaviour {


	private float nextActionTime = 0.0f;
	public float period = 1.5f;
	public GameObject blockDos1;
	public GameObject blockDos2;
	bool setActiveStats = true;
	// Use this for initialization
	void Start () {
		blockDos1.SetActive ( !blockDos1.activeSelf);
		blockDos2.SetActive (setActiveStats);
		setActiveStats = !setActiveStats;
	}
	
	// Update is called once per frame
	void Update () {
		nextActionTime += Time.deltaTime;
		if (nextActionTime > period ) {
			nextActionTime = 0;
			blockDos1.SetActive ( !blockDos1.activeSelf);
			blockDos2.SetActive (setActiveStats);
			setActiveStats = !setActiveStats;
		}

	}
}
