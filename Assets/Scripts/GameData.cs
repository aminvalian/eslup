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
    public bool timerIsRunning;
    public int energy;
    public int refillPeriod;
    public int maxEnergy;
    public int batteries;

    // Use this for initialization
    void Start()
    {
        //		passLevel1 = true;
        currentWinRecord = "";
        energy = PlayerPrefs.GetInt("energy", 5);
        if (data == null)
        {

            DontDestroyOnLoad(gameObject);
            data = this;
            CheckDateAndTime();
        }
        else if (data != this)
        {
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

    public IEnumerator RefillEnergy()
    {
        timerIsRunning = true;
        float refillTimer = PlayerPrefs.GetFloat("refilltimer");

        while (refillTimer > 0)
        {
            
            refillTimer -= 1f;
            PlayerPrefs.SetFloat("refilltimer", refillTimer);
            Debug.Log(PlayerPrefs.GetFloat("refilltimer"));
            yield return new WaitForSeconds(1f);
        }
        if (energy < maxEnergy)
        {
            energy++;
            PlayerPrefs.SetInt("energy", energy);
            
        }
        timerIsRunning = false;
        PlayerPrefs.SetFloat("refilltimer", 0);
        SetLastLifeUseNow();
        CheckDateAndTime();
    }

    public void CheckDateAndTime()
    {
        float time = 0;
        int lifes = 0;
        System.DateTime lastUse = new System.DateTime(
            PlayerPrefs.GetInt("LastUseYear", 2017),
            PlayerPrefs.GetInt("LastUseMonth", 1),
            PlayerPrefs.GetInt("LastUseDay", 1),
            PlayerPrefs.GetInt("LastUseHour", 0),
            PlayerPrefs.GetInt("LastUseMinute", 0),
            PlayerPrefs.GetInt("LastUseSecond", 0));

        time = (float)((System.DateTime.Now - lastUse).TotalSeconds);

        lifes = (int)(time / (60 * refillPeriod));
        energy += lifes;
        if (energy >= 5)
        {
            energy = 5;
            PlayerPrefs.SetFloat("refilltimer", 0);
            SetLastLifeUseNow();
        }
        else if (!timerIsRunning)
        {
                PlayerPrefs.SetFloat("refilltimer", (refillPeriod * 60) - (time % (60 * refillPeriod)));
                Debug.Log((System.DateTime.Now - lastUse).TotalSeconds);
                StartCoroutine(RefillEnergy());
            
        }

    
    }
    public void SetLastLifeUseNow()
    {
            PlayerPrefs.SetInt("LastUseYear", int.Parse(System.DateTime.Now.ToString("yyyy")));
            PlayerPrefs.SetInt("LastUseMonth", int.Parse(System.DateTime.Now.ToString("MM")));
            PlayerPrefs.SetInt("LastUseDay", int.Parse(System.DateTime.Now.ToString("dd")));
            PlayerPrefs.SetInt("LastUseHour", int.Parse(System.DateTime.Now.ToString("HH")));
            PlayerPrefs.SetInt("LastUseMinute", int.Parse(System.DateTime.Now.ToString("mm")));
            PlayerPrefs.SetInt("LastUseSecond", int.Parse(System.DateTime.Now.ToString("ss")));
    }
    // Update is called once per frame
    void Update () {
	
	}
}
