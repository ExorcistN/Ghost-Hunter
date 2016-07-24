using UnityEngine;
using System.Collections;

public class MeleeAttack2 : MonoBehaviour 
{
    private PlayControl2 player;
    public int damageToGive;
    public GameObject character;
    private float attackTimer;
    private float cdAttack;
	// Use this for initialization
	void Start () 
    {
        player = FindObjectOfType<PlayControl2>();

        if (player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        attackTimer = 1;
        cdAttack = 3;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (cdAttack < attackTimer)/**/
        {
            Destroy(gameObject);
        }
        cdAttack -= attackTimer;

        Debug.Log(cdAttack);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager2>().giveDamage(damageToGive);
            Destroy(gameObject);
            //    //ScoreManager.AddPoints(10);
        }
        //Destroy(gameObject);
    }
}
