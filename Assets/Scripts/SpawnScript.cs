using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject pulse;
	public int health;
	public timer winAnnouncer;

	// Use this for initialization
	void Start () {
		health = 5;

	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches){
			if (touch.phase == TouchPhase.Began && !winAnnouncer.winLevel && !winAnnouncer.loseLevel){
				//check if mouse position is on the spawn
				RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity, 1<<11);
				if(ray){
					//destroy existing pulse
					GameObject[] p = GameObject.FindGameObjectsWithTag("Pulse");
					if (p.Length > 0){
						for (int i = 0; i < p.Length;i++)
							Destroy(p[i]);
					}
					//creat new pulse
					Instantiate(pulse,new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,-5f),Quaternion.identity);
				}
			}
		}
		if(Input.GetMouseButtonDown(0)&& !winAnnouncer.winLevel && !winAnnouncer.loseLevel){
			//check if mouse position is on the spawn
			RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity, 1<<11);
			if(ray){
				//destroy existing pulse
				GameObject p = GameObject.Find("Pulse(Clone)");
				if (p != null){
					Destroy(p);
				}
				//creat new pulse
				Instantiate(pulse,new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,-5f),Quaternion.identity);
			}
		}

	}

//	void OnTriggerEnter2D(Collider2D collider){
//		if (collider.tag == "oPulse"){
//			health --;
//			Destroy(collider.gameObject);
//		}
//	}
}
