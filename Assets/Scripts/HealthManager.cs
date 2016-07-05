using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int MaxPlayerHealth;
    public static int playerHealth;
    public static bool isDead;

    Text text;

    private LevelManager levelManager;


	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        playerHealth = MaxPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();

        isDead = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0 && !isDead)
        {
            levelManager.DeadPlayer();
            isDead = true;
            text.text = "0";
        }
        else
        {
            text.text = "" + playerHealth;
        }
	}

    public static void HurtPlayer(int damageR)
    {
        if (!isDead)
        {
            playerHealth -= damageR;
        }

    }
}
