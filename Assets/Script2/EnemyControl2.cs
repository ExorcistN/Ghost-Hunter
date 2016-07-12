using UnityEngine;
using System.Collections;

public class EnemyControl2 : MonoBehaviour 
{
    public Transform target;
    public Transform Transformenemy;
    public float speed;
    public float rotationSpeed;
    public bool enemyIncheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Transformenemy.position.x-5 < target.position.x)
        {
            if (target.position.x - 1 < Transformenemy.position.x && enemyIncheck == true)
            {
                Transformenemy.position += -Transformenemy.right * speed * Time.deltaTime;
                Transformenemy.localScale = new Vector3(1f, 1f, 1f);
            }            
            else
            {
                enemyIncheck = false;
            }
            if (enemyIncheck == false)
            {
                Transformenemy.position += Transformenemy.right * speed * Time.deltaTime;
                Transformenemy.localScale = new Vector3(-1f, 1f, 1f);
                if (Transformenemy.position.x > target.position.x + 1)
                {
                    enemyIncheck = true;
                }
            }
        }
	
	}
}
