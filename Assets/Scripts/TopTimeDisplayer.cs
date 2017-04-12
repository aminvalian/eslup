using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopTimeDisplayer : MonoBehaviour {
	public GameData data;
    public List<Text> topTime = new List<Text>();
    public GameObject nextLevel;
	void Start () {

		Destroy (GameObject.Find("SpawnArea"));
		Destroy (GameObject.Find("OSpawnArea"));

		data = GameObject.Find("GameData").GetComponent<GameData>();
		for (int i = 0 ; i <5; i++){
			topTime[i].text = data.stringRecords[i];
            Debug.Log(data.stringRecords[i]);
		}
//		if (Application.loadedLevel == 1)
			topTime [5].text = data.currentWinRecord;
        if(data.level == 61)
        {
            Destroy(nextLevel);
        }
    }
	
	void Update () {


	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");

	}

	public void LoadNextLevel()
	{
		if ( data.level%10 == 5)
			data.level +=6;
		else 
			data.level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

}
