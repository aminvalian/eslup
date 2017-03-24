using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

	public static GameData data;
	public bool online;
	public string[] topWinTimesLevel2SM = new string[5];
	public string currentWinRecord;
	public List<string> stringRecords = new List<string>();
	public List<float> records = new List<float>();
	public int gameMode = 0; 
	public int level;


		// Use this for initialization
	void Start () {
//		passLevel1 = true;
		currentWinRecord = "";

		if(data == null){

			DontDestroyOnLoad(gameObject);
			data = this;
		}else if(data!= this){
			Destroy(gameObject);
		}
	}

	public void saveRecord(float t){
		records.Clear();
		for(int i = 0; i<5;i++){
			records.Add(PlayerPrefs.GetFloat(level.ToString()+i.ToString(),0));
		}
		for(int i = 0; i<5;i++){
			if(records[i] < t){
				for(int j = 4; j>=i; j--){
					PlayerPrefs.SetFloat((level).ToString()+(j+1).ToString(),PlayerPrefs.GetFloat((level).ToString()+(j).ToString()));
				}
				PlayerPrefs.SetFloat((level).ToString()+(i).ToString(),t);
				i = 5;
			}
		}
		refreshRecords();
        Debug.Log("saved");
	}
	public void refreshRecords(){
		records.Clear();
		for(int i = 0; i<5;i++){
			records.Add(PlayerPrefs.GetFloat(level.ToString()+i.ToString(),0));
		}
		timer time = GameObject.Find("Main Camera").GetComponent<timer>();
		stringRecords.Clear();
		for(int i = 0; i<5;i++){
			records[i] = PlayerPrefs.GetFloat(level.ToString()+i.ToString());
			stringRecords.Add(time.TimeToString(records[i]));
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
