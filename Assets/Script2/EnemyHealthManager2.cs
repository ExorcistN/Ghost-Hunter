using UnityEngine;
using System.Collections;

public class EnemyHealthManager2 : MonoBehaviour 
{
    public int enemyHealth;

    public int pointsOnDeath;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (enemyHealth <= 0)
        {
            ScoreChar.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }
	}
    public void giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}
