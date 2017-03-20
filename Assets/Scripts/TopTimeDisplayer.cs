using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TopTimeDisplayer : MonoBehaviour {
	public GameData data;
//	public timer time;
	public List<Text> topTime = new List<Text>();

	void Start () {

		Destroy (GameObject.Find("SpawnArea"));
		Destroy (GameObject.Find("OSpawnArea"));

		data = GameObject.Find("GameData").GetComponent<GameData>();
		for (int i = 0 ; i <5; i++){
			topTime[i].text = data.stringRecords[i];
		}
//		if (Application.loadedLevel == 1)
			topTime [5].text = data.currentWinRecord;
	}
	
	void Update () {


	}

	public void LoadMainMenu()
	{
		Application.LoadLevel ("MainMenu");

	}

	public void LoadNextLevel()
	{
		if ( data.level%10 == 5)
			data.level +=6;
		else 
			data.level++;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
