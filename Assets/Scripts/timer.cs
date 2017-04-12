using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
	public Text timerLabel;
	public float time = 10.00f;
	public float winTime;
	public bool winLevel;
	public bool timedOut;
    public bool pulseReleased;
    public int signals;
    public Text winTimeText;

	void Start(){
		winLevel = false;
		timedOut = false;
	}




	void Update() {


		if (winLevel) {
			winTime = time;
//			winTimeText.text = (TimeToString(winTime));
		} 

		else {
			if (time < 0 && !timedOut && !GameObject.FindWithTag("Pulse")) {
				GameObject.Find("Canvas").SetActive(false);
				GameObject.Find("EventSystem").SetActive(false);
                SceneManager.LoadScene("LosePage", LoadSceneMode.Additive);
				timedOut = true;
				Destroy(GameObject.FindWithTag("Pulse"));
			}
			else {
                if(time >= 0)
				    time -= Time.deltaTime;
                if (time < 0)
                    time = 0;
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
		float seconds = timee % 60;//Use the euclidean division for the seconds.
		float fraction = (timee * 100) % 100;
		timeText = string.Format ("{0:00} : {1:00}", seconds, fraction);
		return timeText;
	}


	public void LoadMainMenu()
	{
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
	}

	public void RestartLevel()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
