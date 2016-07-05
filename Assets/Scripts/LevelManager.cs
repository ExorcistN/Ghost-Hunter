using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject deadparticle;
    public GameObject currentCheckpoint;
    public float respawnDelay;

    private PlayerControl player;

    

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControl>();

        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    public void DeadPlayer() {
        //Debug.Log("Player Respawn");
        player.DelCharacter();
        StartCoroutine("DeadPlayerCo");
        
    }
    public IEnumerator DeadPlayerCo()
    {
        yield return new WaitForSeconds(respawnDelay);
        Instantiate(deadparticle, player.transform.position, player.transform.rotation);
        player.GetComponent<Renderer>().enabled = false;
        //yield return new WaitForSeconds(1);
        //player.transform.position = currentCheckpoint.transform.position;
        //player.spawnCharacter();
        //player.GetComponent<Renderer>().enabled = true;

    }

}
