using UnityEngine;
using System.Collections;

public class BulletControl2 : MonoBehaviour {


    public float speedbullet;
    public PlayControl2 player2;
	// Use this for initialization
	void Start () {
        player2 = FindObjectOfType<PlayControl2>();

        if (player2.transform.localScale.x < 0)
        {
            speedbullet = -speedbullet;
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else 
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedbullet, GetComponent<Rigidbody2D>().velocity.y);
        if (transform.position.x < player2.transform.position.x - 4 || transform.position.x > player2.transform.position.x + 4)
        {
            //Destroy(gameObject);
        }
	}
}
