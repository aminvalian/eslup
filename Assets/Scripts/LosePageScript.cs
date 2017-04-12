using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LosePageScript : MonoBehaviour {

    GameData data;
	// Use this for initialization
	void Start () {

        data = GameObject.Find("GameData").GetComponent<GameData>();
	}



	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
		
	}
	
	public void TryAgain()
	{
        if (data.energy > 0)
        {
            data.energy--;
            PlayerPrefs.SetInt("energy", data.energy);
            data.SetLastLifeUseNow();
            data.CheckDateAndTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //show buy energy
        }
    }
    public void OneMoreChance() {
        //battery -=3;

    } 

}
