using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager2 : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayControl2 player;
    public HealthManager2 healthManager;
	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<PlayControl2>();
        healthManager = FindObjectOfType<HealthManager2>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.GetComponent<Renderer>().enabled = false;
        //player.healthManager.HurtPlayer();
    }

    
}
