using UnityEngine;
using System.Collections;

public class LosePageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (GameObject.Find("SpawnArea"));
		Destroy (GameObject.Find("OSpawnArea"));
	}



	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadMainMenu()
	{
		Application.LoadLevel ("MainMenu");
		
	}
	
	public void TryAgain()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
}
