using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlockScript : MonoBehaviour {
	public float maxRange;
	public float minRange;
	public float maxSpeed;
	public timer winAnnouncer;
    public bool easeIN;
    public bool isMoving;
    public bool easeOUT; 
    private SpriteRenderer sRenderer;
    public AudioClip pulseHittingBlock1;
	AudioSource audio;

	void Start () {
        sRenderer = GetComponent<SpriteRenderer>();
        winAnnouncer = GameObject.Find("Main Camera").GetComponent<timer>();
		if (transform.position.x > 0){         
			maxSpeed = -Mathf.Abs(maxSpeed);
		}else{
			maxSpeed = Mathf.Abs(maxSpeed);
		}
		audio = GetComponent<AudioSource>();
	}

    void Update()
    {
        if (transform.position.x > maxRange)
        {
            transform.position = new Vector2(maxRange, transform.position.y);
            maxSpeed = -maxSpeed;
        }
        if (transform.position.x < minRange)
        {
            transform.position = new Vector2(minRange, transform.position.y);
            maxSpeed = -maxSpeed;
        }
        if (isMoving)
        {
            float speed;
            if (easeOUT)
            {
                speed = ((Mathf.Abs(transform.position.x) / maxRange) * maxSpeed * 0.9f) + (maxSpeed * 0.1f);

            }
            else if (easeIN)
            {
                speed = Mathf.Lerp(0.9f, 0.1f, (Mathf.Abs(transform.position.x) / maxRange)) * maxSpeed;
                //speed = ((Mathf.Abs(transform.position.x) - maxRange) * maxSpeed * 0.9f) + (maxSpeed * 0.1f);
            }
            else
            {
                speed = maxSpeed;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        //sRenderer.material.color = new Color(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)/5f, 0f, 0f, 0.1f);
    }
    void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Pulse" ){
            winAnnouncer.pulseReleased = false;
            audio.PlayOneShot(pulseHittingBlock1, 0.7f);
            collider.GetComponent<Animator>().SetTrigger("destroy");
            Destroy(collider.gameObject, 0.4f);
            if (winAnnouncer.signals == 0)
            {
                collider.GetComponent<Animator>().SetTrigger("destroy");
                Destroy(collider.gameObject, 0.4f);
                collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GameObject.Find("Canvas").SetActive(false);
                GameObject.Find("EventSystem").SetActive(false);
                winAnnouncer.timedOut = true;
                audio.PlayOneShot(pulseHittingBlock1, 0.7f);
                GameObject.Find("GameData").GetComponent<GameData>().refreshRecords();
                StartCoroutine(startAfterOneSec());
            }
		}
	}
	
	IEnumerator startAfterOneSec(){
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene("LosePage",LoadSceneMode.Additive);
		
	}
}
