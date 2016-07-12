using UnityEngine;
using System.Collections;

public class LevelManager2 : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayControl2 player;
	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<PlayControl2>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.GetComponent<Renderer>().enabled = false;
    }
}
