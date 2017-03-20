using UnityEngine;
using System.Collections;

public class GameIntroScript : MonoBehaviour {

    public GameObject[] intros;
	// Use this for initialization
	void Start () {
        int p = PlayerPrefs.GetInt("played", 0);
        if(p == 0)
        {
            PlayerPrefs.SetInt("played",1);
            ShowHelp();
        }
        
	}
	
	public void ShowHelp()
    {
        for (int i = 0; i< intros.Length; i++)
        {
            intros[i].SetActive(true);
        }
    }

    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began )
            {
                //check if mouse position is on the spawn
                RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 1 << 11);
                if (ray)
                {
                    HideHelp();
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            //check if mouse position is on the spawn
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 1 << 11);
            if (ray)
            {
                HideHelp();
            }
        }
    }

    public void HideHelp()
    {
        for (int i = 0; i < intros.Length; i++)
        {
            intros[i].SetActive(false);
        }
    }
}
