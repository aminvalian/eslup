using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public float maxRange;
	public float minRange;
	public float speed;
	public timer winAnnouncer;

	public AudioClip pulseHittingBlock1;
	AudioSource audio;

	void Start () {
		if (transform.position.x > 0){         
			speed = -Mathf.Abs(speed);
		}else{
			speed = Mathf.Abs(speed);
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		audio = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (transform.position.x > maxRange){
			transform.position = new Vector2(maxRange,transform.position.y);
			speed = -speed;
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		}
		if (transform.position.x < minRange ){
			transform.position = new Vector2(minRange,transform.position.y);
			speed = -speed;
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Pulse" || collider.tag == "oPulse"){
			collider.GetComponent<Animator>().SetTrigger("destroy");
			Destroy(collider.gameObject, 0.4f);
			collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GameObject.Find("Canvas").SetActive(false);
			GameObject.Find("EventSystem").SetActive(false);
			winAnnouncer.loseLevel = true;
			audio.PlayOneShot (pulseHittingBlock1,0.7f);
			GameObject.Find("GameData").GetComponent<GameData>().refreshRecords();
			StartCoroutine(startAfterOneSec());
		}
	}
	
	IEnumerator startAfterOneSec(){
		yield return new WaitForSeconds(0.8f);
		Application.LoadLevelAdditive("LosePage");
		
	}
}
