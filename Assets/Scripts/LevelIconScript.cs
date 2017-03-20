using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelIconScript : MonoBehaviour {
	public List<Sprite> levelIcons = new List<Sprite>();
	public Text levelNumber;
	// Use this for initialization
	void Start () {
		GetComponent<Image>().sprite = levelIcons[(GameObject.Find("GameData").GetComponent<GameData>().level/10)-1];
		levelNumber.text = (GameObject.Find("GameData").GetComponent<GameData>().level%10).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
