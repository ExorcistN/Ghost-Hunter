using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private PlayerControl player;

    public int damageToGive;

    public GameObject character;

    private float attackTimer = 1;
    private float AllTimeAttack = 3;

    public float knockbacklenght;



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
    }

    // Update is called once per frame
    void Update()
    {
        if (AllTimeAttack<attackTimer)
        {
            Destroy(gameObject);
        }
        AllTimeAttack -= attackTimer;
        
        Debug.Log(AllTimeAttack);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            if (other.transform.localScale.x > 0)
            {
                //other.transform.position += transform.right * 40 * Time.deltaTime;
                other.transform.position += transform.right * knockbacklenght;
            }
            else
            {
                //other.transform.position -= transform.right * 40 * Time.deltaTime;
                other.transform.position -= transform.right * knockbacklenght;
            }
            Destroy(gameObject);
            //    //ScoreManager.AddPoints(10);
        }
        //Destroy(gameObject);
    }
}
