﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public GameObject singlePlayer, multiPlayerOnline,multiPlayerOffline,
	sMlevels, mPOnlinelevels, mPOfflinelevels, exit,levelOne,levelTwo, levelThree, levelFour,levelFive,
	levels,firstLevel,secondLevel,thirdLevel,fourthLevel,fifthLevel,acrossDos,back,setting,resetLevels, aboutUs, howToPlay, howToPlayScrn, aboutUsScrn , resetWarning;
	public GameData data;
	public List<GameObject> btns = new List<GameObject>();
	public int headerCount = 0;
	//public GameObject smPlayer;
	//public GameObject levels;

	void Start () {
		btns.Add(firstLevel);
		btns.Add(secondLevel);
		btns.Add(thirdLevel);
		btns.Add(fourthLevel);
		btns.Add(fifthLevel);
		data = GameObject.Find("GameData").GetComponent<GameData>();
		sMlevels.SetActive(false);
		mPOnlinelevels.SetActive(false);
		mPOfflinelevels.SetActive(false);

		singlePlayer.SetActive(true);
		multiPlayerOnline.SetActive(true);
		multiPlayerOffline.SetActive(false);
		setting.SetActive (true);
		resetLevels.SetActive (false);
		aboutUs.SetActive (false);
		howToPlay.SetActive (false);
		exit.SetActive(true);
		if (data.gameMode == 1) {
			SinglePlayerClick();
		}

	}

	void Update () {
		
	}

	public void SinglePlayerClick(){
		data.gameMode = 1;
		singlePlayer.SetActive (false);
		multiPlayerOnline.SetActive (false);
		multiPlayerOffline.SetActive (false);
		exit.SetActive (false);
		back.SetActive(true);
		setting.SetActive(false);
		sMlevels.SetActive (true);
		acrossDos.SetActive( false);
		if ( PlayerPrefs.GetFloat("550",0)>0)
			acrossDos.SetActive( true);

	}

	public void SMlevelone(){
		data.level = 10;
		levels.transform.position = levelOne.transform.position;
		levelOne.SetActive(false);
		levelTwo.SetActive(true);
		levelThree.SetActive(true);
		levelFour.SetActive(true);
		levelFive.SetActive(true);
		levels.SetActive(true);
		checkLevels(1);
	}
	public void SMleveltwo(){
		data.level = 20;
		levels.transform.position = levelTwo.transform.position;
		levelOne.SetActive(true);
		levelTwo.SetActive(false);
		levelThree.SetActive(true);
		levelFour.SetActive(true);
		levelFive.SetActive(true);
		levels.SetActive(true);
		checkLevels(2);
	}

	public void SMlevelthree(){
		data.level = 30;
		levels.transform.position = levelThree.transform.position;
		levelOne.SetActive(true);
		levelTwo.SetActive(true);
		levelThree.SetActive(false);
		levelFour.SetActive(true);
		levelFive.SetActive(true);
		levels.SetActive(true);
		checkLevels(3);
	}
	public void SMlevelfour(){
		data.level = 40;
		levels.transform.position = levelFour.transform.position;
		levelOne.SetActive(true);
		levelTwo.SetActive(true);
		levelThree.SetActive(true);
		levelFour.SetActive(false);
		levelFive.SetActive(true);
		levels.SetActive(true);
		checkLevels(4);
	}
	public void SMlevelfive(){
		data.level = 50;
		levels.transform.position = levelFive.transform.position;
		levelOne.SetActive(true);
		levelTwo.SetActive(true);
		levelThree.SetActive(true);
		levelFour.SetActive(true);
		levelFive.SetActive(false);
		levels.SetActive(true);
		checkLevels(5);
	}
	public void LevelOne(){
		int level = data.level;
		data.level += 1;
		Application.LoadLevel(((level/10)-1)*5+3);
	}
	public void LevelTwo(){
		int level = data.level;
		data.level += 2;
		Application.LoadLevel(((level/10)-1)*5+4);
	}
	public void LevelThree(){
		int level = data.level;
		data.level += 3;
		Application.LoadLevel(((level/10)-1)*5+5);
	}
	public void LevelFour(){
		int level = data.level;
		data.level += 4;
		Application.LoadLevel(((level/10)-1)*5+6);
	}
	public void LevelFive(){
		int level = data.level;
		data.level += 5;
		Application.LoadLevel(((level/10)-1)*5+7);
	}

	public void LevelSix(){
		data.level = 61;
		Application.LoadLevel(28);
	}


	public void Exit()
	{
		Application.Quit();
	}

	public void SettingClicked(){
		singlePlayer.SetActive(false);
		multiPlayerOnline.SetActive (false);
		setting.SetActive(false);
		exit.SetActive(false);
		back.SetActive(true);
		resetLevels.SetActive (true);
		aboutUs.SetActive (true);
		howToPlay.SetActive (true);

	}

	public void backClicked(){
		data.gameMode = 0;
		Application.LoadLevel(0);

	}

	public void ResetClicked()
	{
		back.GetComponent<Button>().interactable = false;
		aboutUs.GetComponent<Button>().interactable = false;
		howToPlay.GetComponent<Button>().interactable = false;
		resetLevels.GetComponent<Button>().interactable = false;
		resetWarning.SetActive(true);
	}

	public void AboutUsClicked()
	{
		resetLevels.SetActive(false);
		aboutUs.SetActive(false);
		howToPlay.SetActive(false);
		aboutUsScrn.SetActive(true);
	}

	public void HowToPlay()
	{
		resetLevels.SetActive(false);
		aboutUs.SetActive(false);
		howToPlay.SetActive(false);
		howToPlayScrn.SetActive(true);
	}

	public void ResetYes(){
		PlayerPrefs.DeleteAll();
		back.GetComponent<Button>().interactable = true;
		aboutUs.GetComponent<Button>().interactable = true;
		howToPlay.GetComponent<Button>().interactable = true;
		resetLevels.GetComponent<Button>().interactable = true;
		resetWarning.SetActive(false);
	}

	public void ResetNo(){

		back.GetComponent<Button>().interactable = true;
		aboutUs.GetComponent<Button>().interactable = true;
		howToPlay.GetComponent<Button>().interactable = true;
		resetLevels.GetComponent<Button>().interactable = true;
		resetWarning.SetActive(false);
	}
	public void headerClicked(){
		headerCount++;
		if (headerCount == 10){
			openAll();
		}
	}

	private void openAll(){
		for (int i = 1 ; i<6; i++){
			for (int j = 1 ; j<6; j++){
				if(PlayerPrefs.GetFloat(i.ToString()+(j).ToString()+"0", 0f) == 0f){
					PlayerPrefs.SetFloat(i.ToString()+(j).ToString()+"0", 1f);
				}
			}
		}
		PlayerPrefs.SetFloat("610", 0.01f);
	}

	public void checkLevels(int level){
		for (int i = 1 ; i<5; i++){
			if(PlayerPrefs.GetFloat(level.ToString()+(i).ToString()+"0", 0f) == 0f){
				btns[i-1].GetComponent<Button>().interactable = false;
			}
			else{
				btns[i-1].GetComponent<Button>().interactable = true;
			}
		}
	}

	/*
	public void levelOne(){
		data.level = "1";
		smPlayer.SetActive(true);
		levels.SetActive(false);
	}
	public void offlineMode(){
		data.online = false;
		Application.LoadLevel(data.level);
	}
	public void onlineMode(){
		smPlayer.SetActive(true);
		data.online = true;
		Application.LoadLevel(data.level);
	}
*/
}
