using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public Text timerLabel;
	public float time = 10.00f;
	public float winTime;
	public bool winLevel;
	public bool loseLevel;
	public Text winTimeText;

	void Start(){
		winLevel = false;
		loseLevel = false;
	}




	void Update() {


		if (winLevel) {
			winTime = time;
//			winTimeText.text = (TimeToString(winTime));
		} 

		else {
			if (time <= 0 && !loseLevel) {
				GameObject.Find("Canvas").SetActive(false);
				GameObject.Find("EventSystem").SetActive(false);
				Application.LoadLevelAdditive ("LosePage");
				loseLevel = true;
				Destroy(GameObject.FindWithTag("Pulse"));
			}
			else {
				time -= Time.deltaTime;
				timerLabel.text = TimeToString(time);

//				float minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
//				float seconds = time % 60;//Use the euclidean division for the seconds.
//				float fraction = (time * 100) % 100;
//		
//				//update the label value
//				timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
//		
			}
		}
	}

	public string TimeToString(float timee){
		string timeText;
		float minutes = timee / 60; //Divide the guiTime by sixty to get the minutes.
		float seconds = timee % 60;//Use the euclidean division for the seconds.
		float fraction = (timee * 100) % 100;
		timeText = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
		return timeText;
	}


	public void LoadMainMenu()
	{
	
		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

}
