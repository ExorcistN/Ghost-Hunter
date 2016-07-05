using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{

    public Transform target;
    public Transform enemyTransform;
    public float speed;
    public float rotationSpeed;
    private bool enemyInCheck;

    void Start()
    {

    }

    void Update()
    {
        //rotate to look at the player

        //transform.LookAt(target.position, upAxis);
        //transform.eulerAngles = new Vector3(0f, 0f, 0f);
        //move towards the player

        if (enemyTransform.position.x-5 < target.position.x ) //when player near enemy in 5m.
        {
            if (target.position.x - 1 < enemyTransform.position.x && enemyInCheck == true)
            {
                enemyTransform.position += -enemyTransform.right * speed * Time.deltaTime;
                enemyTransform.localScale = new Vector3(0.6280f, 0.6280f, 0.6280f);
            }
            else
            {
                enemyInCheck = false;
            }
            if (enemyInCheck == false)
            {
                enemyTransform.position += enemyTransform.right * speed * Time.deltaTime;
                enemyTransform.localScale = new Vector3(-0.6280f, 0.6280f, 0.6280f);
                if (enemyTransform.position.x > target.position.x + 1)
                {
                    enemyInCheck = true;
                }
            }
        }
    }
}
