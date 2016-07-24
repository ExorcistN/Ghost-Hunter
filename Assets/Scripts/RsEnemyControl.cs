using UnityEngine;
using System.Collections;

public class RsEnemyControl : MonoBehaviour {

    public Transform target;
    public Transform enemyTransform;
    public float speed;
    public float rotationSpeed;


    public int damageToGive;

    private bool enemyInCheckX;
    private bool enemyInCheckY;
    private float topflycheck = 0.1f;

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
            //Up&down
            if (enemyTransform.position.y > topflycheck - 1.5f && enemyInCheckY == true)
            {
                enemyTransform.position += -enemyTransform.up * speed * Time.deltaTime;
            }
            else
            {
                enemyInCheckY = false;
            }
            if (enemyInCheckY == false)
            {
                enemyTransform.position += enemyTransform.up * speed * Time.deltaTime;
                if (enemyTransform.position.y > topflycheck)
                {
                    enemyInCheckY = true;
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
