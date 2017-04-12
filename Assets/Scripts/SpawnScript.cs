using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour {
	public GameObject pulse;
	public int health;
	public timer winAnnouncer;
    public int type;
    public float spawnY;
    public GameData data;
    public SpawnScript firstSpawn;
    public Sprite onSprite;
    public Sprite offSprite;
    public AudioSource aliveSound;
    private SpriteRenderer spriteRenderer;
    public Animator spawnPulseUiAnim;
    public GameObject spawnPulseUiObject;
    public List<GameObject> spawnPulseUiobjects = new List<GameObject>();
    // Use this for initialization
    void Start () {
		health = 5;
        spriteRenderer = GetComponent<SpriteRenderer>();
        winAnnouncer = GameObject.Find("Main Camera").GetComponent<timer>();
        data = GameObject.Find("GameData").GetComponent<GameData>();
    }

    

    // Update is called once per frame
    void Update () {
        if (type == 0)
        {
            if (winAnnouncer.pulseReleased)
            {
                spriteRenderer.sprite = offSprite;
            }
            else if(winAnnouncer.signals >0)
            {
                spriteRenderer.sprite = onSprite;
            }
            if (winAnnouncer.winLevel)
            {
                spriteRenderer.sprite = offSprite;
                spawnPulseUiObject.SetActive(false);
            }
        }
		foreach(Touch touch in Input.touches){
			if (touch.phase == TouchPhase.Began && !winAnnouncer.winLevel && !winAnnouncer.timedOut && type == 0 && winAnnouncer.signals > 0 && !winAnnouncer.pulseReleased)
            {
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
					Instantiate(pulse,new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,spawnY),Quaternion.identity);
                    spawnPulseUiobjects[winAnnouncer.signals].SetActive(false);
                    winAnnouncer.signals--;
                    spawnPulseUiAnim.SetTrigger("fire");
                    if (winAnnouncer.signals == 0)
                    {
                        spriteRenderer.sprite = offSprite;
                    }
                    winAnnouncer.pulseReleased = true;
                }
			}
		}
		if(Input.GetMouseButtonDown(0)&& !winAnnouncer.winLevel && !winAnnouncer.timedOut && type == 0 && winAnnouncer.signals > 0 && !winAnnouncer.pulseReleased){
			//check if mouse position is on the spawn
			RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity, 1<<11);
			if(ray){
				//destroy existing pulse
				GameObject p = GameObject.Find("Pulse(Clone)");
				if (p != null){
					Destroy(p);
				}
                //creat new pulse
				Instantiate(pulse,new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x,spawnY),Quaternion.identity);
                winAnnouncer.signals--;
                spawnPulseUiAnim.SetTrigger("fire");
                spawnPulseUiobjects[winAnnouncer.signals ].SetActive(false);
                if (winAnnouncer.signals == 0)
                {
                    spriteRenderer.sprite = offSprite;
                }
                winAnnouncer.pulseReleased = true;
            }
        }

	}

    //public IEnumerator ComeAlive()
    //{
    //    if (winAnnouncer.signals > 0 || type == 2)
    //        spriteRenderer.sprite = onSprite;
    //    yield return new WaitForSeconds(Random.Range(0.05f,0.1f));
    //    spriteRenderer.sprite = offSprite;
    //    yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
    //    if (winAnnouncer.signals > 0 || type == 2)
    //        spriteRenderer.sprite = onSprite;
    //    yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
    //    spriteRenderer.sprite = offSprite;
    //    yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));
    //    if (winAnnouncer.signals > 0 || type == 2)
    //        spriteRenderer.sprite = onSprite;
    //    if(Random.Range(0, 1f) > 0.8 )
    //    {
    //        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            
    //        spriteRenderer.sprite = offSprite;
    //        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
    //        if (winAnnouncer.signals > 0 || type == 2)
    //            spriteRenderer.sprite = onSprite;
    //    }
    //}

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pulse")
        {
            if (type == 2)
            {
                aliveSound.Play();
                winAnnouncer.signals++;
                winAnnouncer.winLevel = true;
                winAnnouncer.winTime = winAnnouncer.time;
                spriteRenderer.sprite = onSprite;
                data.saveRecord(winAnnouncer.winTime);
                Destroy(collider.gameObject);
                data.currentWinRecord = winAnnouncer.TimeToString(winAnnouncer.winTime);
                GameObject.Find("Canvas").SetActive(false);
                GameObject.Find("EventSystem").SetActive(false);
                winAnnouncer.pulseReleased = false;
                spawnPulseUiObject.SetActive(true);
                for (int i = 0; i < winAnnouncer.signals; i++)
                {
                    spawnPulseUiobjects[i].SetActive(true);
                }
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("WinPage", LoadSceneMode.Additive);
                //(gameObject.gameObject);
            }
            else if(type == 1)
            {
                aliveSound.Play();
                GameObject.Find("Main Camera").GetComponent<Animator>().SetTrigger("pass");
                firstSpawn.type = -1;
                winAnnouncer.signals++;
                Destroy(firstSpawn.gameObject, 2f);
                winAnnouncer.pulseReleased = false;
                spawnPulseUiObject.SetActive(true);
                for(int i = 0; i < winAnnouncer.signals; i++)
                {
                    spawnPulseUiobjects[i].SetActive(true);
                }
                spriteRenderer.sprite = onSprite;
                type = 0;
                Destroy(GameObject.FindWithTag("Pulse"));
            }
        }
    }

}
