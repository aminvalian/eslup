using UnityEngine;
using System.Collections;
//using UnityEngine.Advertisements;

public class OSpawnScript : MonoBehaviour {
	public int health;
	public GameObject oPulse;
	public GameData data;
	public timer winAnnouncer;

	void Start () {
		data = GameObject.Find("GameData").GetComponent<GameData>();
//		health = 5;
	}



//	void Update () {
//		foreach(Touch touch in Input.touches){
//			if (touch.phase == TouchPhase.Began){
//
//				//check if mouse position is on the spawn
//				RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity, 1<<12);
//				if(ray){
//					//destroy existing opulse
//					GameObject p = GameObject.Find("oPulse(Clone)");
//					if (p != null){
//						Destroy(p);
//					}//creat new pulse
//					Instantiate(oPulse,new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,5f),Quaternion.identity);
//				}
//			}
//		}
//		// if mouse leftclick
//		if(Input.GetMouseButtonDown(0) && !data.online){
//
//			//check if mouse position is on the spawn
//			RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity, 1<<12);
//			if(ray){
//				//destroy existing pulse
//				GameObject p = GameObject.Find("oPulse(Clone)");
//				if (p != null){
//					Destroy(p);
//				}//creat new pulse
//				Instantiate(oPulse,new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,5f),Quaternion.identity);
//			}
//		}
//	}

	IEnumerator OnTriggerEnter2D (Collider2D collider){
		if (collider.tag == "Pulse"){
            //		health --;      ????????
            if (/*Advertisement.IsReady() &&*/ data.level % 5 == 0)
            {
                //Advertisement.Show();
            }
			winAnnouncer.winLevel = true;
			winAnnouncer.winTime = winAnnouncer.time;
			data.saveRecord(winAnnouncer.winTime);
			Destroy(collider.gameObject);
			print (winAnnouncer.winTime);
			data.currentWinRecord = winAnnouncer.TimeToString(winAnnouncer.winTime);
			GameObject.Find("Canvas").SetActive(false);
			GameObject.Find("EventSystem").SetActive(false);
			yield return new WaitForSeconds(.0f);
			Application.LoadLevelAdditive ("WinPage");

			Destroy (gameObject.gameObject);
		}
	}


}
