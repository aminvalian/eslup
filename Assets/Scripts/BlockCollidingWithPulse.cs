using UnityEngine;
using System.Collections;

public class BlockCollidingWithPulse : MonoBehaviour {
	public timer winAnnouncer;
	public AudioClip pulseHittingBlock1;
	AudioSource audio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Pulse" || collider.tag == "oPulse"){
			collider.GetComponent<Animator>().SetTrigger("destroy");
			Destroy(collider.gameObject, 0.4f);
			collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GameObject.Find("Canvas").SetActive(false);
			GameObject.Find("EventSystem").SetActive(false);
			winAnnouncer.loseLevel = true;
			//audio.PlayOneShot (pulseHittingBlock1,0.7f);
			GameObject.Find("GameData").GetComponent<GameData>().refreshRecords();
			StartCoroutine(startAfterOneSec());
		}
	}

	IEnumerator startAfterOneSec(){
		yield return new WaitForSeconds(0.8f);
		Application.LoadLevelAdditive("LosePage");

	}



}
