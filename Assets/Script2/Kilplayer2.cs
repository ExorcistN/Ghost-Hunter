using UnityEngine;
using System.Collections;

public class Kilplayer2 : MonoBehaviour {

    public LevelManager2 levelmanager;

	// Use this for initialization
	void Start () 
    {
	    levelmanager = FindObjectOfType<LevelManager2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "exorcist")
        {
            levelmanager.RespawnPlayer();
        }
    }
}
