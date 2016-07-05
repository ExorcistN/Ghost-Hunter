using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float Bulletspeed;
    private PlayerControl player;

    public int damageToGive;

    //private float leftMap = -6.5f;
    //private float rightMap = 77f;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControl>();

        if (player.transform.localScale.x < 0)
        {
            Bulletspeed = -Bulletspeed;
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Rigidbody2D>().velocity = new Vector2(Bulletspeed,GetComponent<Rigidbody2D>().velocity.y);
        if (transform.position.x < player.transform.position.x-4 || transform.position.x > player.transform.position.x+4)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"){
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
        //    Destroy(other.gameObject);
        //    //ScoreManager.AddPoints(10);
        }
        Destroy(gameObject);
    }
}
