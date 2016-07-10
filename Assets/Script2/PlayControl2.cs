using UnityEngine;
using System.Collections;

public class PlayControl2 : MonoBehaviour {

    public float movespeed;
    public float jumpheight;
    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    public Transform firepoint;
    public GameObject bulleta;
    private Animator anim;
    public float shotDelay;
    private float shotDelayCounter;
	// Use this for initialization
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatIsGround);

    }
	void Start () 
    {
	     anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpheight);
            Debug.Log(GetComponent<Rigidbody2D>().velocity);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Debug.Log("test");
            Debug.Log("test2");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bulleta,firepoint.position,firepoint.rotation);
            anim.Play("exAtk2");
            shotDelayCounter = shotDelay;
        }
        if(Input.GetKey(KeyCode.Return))//shooting delay
        {
            shotDelayCounter -= Time.deltaTime;
            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(bulleta, firepoint.position, firepoint.rotation);
            }
        }
	
	}
}
