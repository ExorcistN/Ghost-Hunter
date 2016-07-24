using UnityEngine;
using System.Collections;

public class LandEnemyControl : MonoBehaviour {

    public Transform target;
    public Transform enemyTransform;
    public float speed;
    public float rotationSpeed;


    public int damageToGive;

    private bool enemyInCheckX;

    void Start()
    {

    }

    void Update()
    {
        //rotate to look at the player

        //transform.LookAt(target.position, upAxis);
        //transform.eulerAngles = new Vector3(0f, 0f, 0f);
        //move towards the player

        if (enemyTransform.position.x - 5 < target.position.x) //when player near enemy in 5m.
        {
            //Left&right
            if (target.position.x - 1 < enemyTransform.position.x && enemyInCheckX == true)
            {
                enemyTransform.position += -enemyTransform.right * speed * Time.deltaTime;
                enemyTransform.localScale = new Vector3(0.6280f, 0.6280f, 0.6280f);
            }
            else
            {
                enemyInCheckX = false;
            }
            if (enemyInCheckX == false)
            {
                enemyTransform.position += enemyTransform.right * speed * Time.deltaTime;
                enemyTransform.localScale = new Vector3(-0.6280f, 0.6280f, 0.6280f);
                if (enemyTransform.position.x > target.position.x + 1)
                {
                    enemyInCheckX = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
            //Debug.Log("test");
        }

    }
}
