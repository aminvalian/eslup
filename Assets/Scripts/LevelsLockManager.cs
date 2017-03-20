using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelsLockManager : MonoBehaviour {

	public List<Button> buttons = new List<Button>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i< buttons.Count; i++){
			if (PlayerPrefs.GetFloat((i+1).ToString()+"50",0) > 0) {
				buttons[i].interactable = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
