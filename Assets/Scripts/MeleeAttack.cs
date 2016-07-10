using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private PlayerControl player;

    public int damageToGive;

    public GameObject character;

    private float attackTimer;
    private float cdAttack;



    //private float leftMap = -6.5f;
    //private float rightMap = 77f;

    // Use this for initialization
    //E:
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();

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
    void Update()
    {
        if (cdAttack<attackTimer)
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
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            Destroy(gameObject);
            //    //ScoreManager.AddPoints(10);
        }
        //Destroy(gameObject);
    }
}
