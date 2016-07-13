using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager2 : MonoBehaviour 
{
    public int maxPlayerHealth;
    public static int playerHealth;
    Text text;
    private LevelManager2 levelmanager;
    public static bool Dead;//deadcheck

	// Use this for initialization
	void Start () 
    {
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelmanager = FindObjectOfType<LevelManager2>();
        Dead = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (playerHealth <= 0 && !Dead)
        {
            levelmanager.RespawnPlayer();
            Dead = true;
            text.text = "0";
        }
        else
        {
            text.text = "" + playerHealth;
        }
	}
    public static void HurtPlayer(int damage)
    {
        if (!Dead)
        {
            playerHealth -= damage;
        }
    }
    /*public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }*/
}
