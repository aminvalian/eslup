using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintfinderScript : MonoBehaviour {
    public GameObject pulse;
    public float timer;
    public float timeDuration;
    public float distance;
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer >= timeDuration)
        {
            for (int i = 0; i < (6 / distance)+1; i++)
            {
                Instantiate(pulse, new Vector2(-3f+(i*distance), -5), Quaternion.identity);
            }
            timer = 0;
        }
        timer += Time.deltaTime;
	}
}
