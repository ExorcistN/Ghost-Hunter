using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;


    private bool deadCheck;

   private Animator anim;

    public Transform firePoint;
    public GameObject bullet;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}

    public void spawnCharacter()
    {
        deadCheck = false;
    }
    public void DelCharacter()
    {
        deadCheck = true;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(gameObject, 0.6f);
    }
    void Update() {
        anim.SetBool("DeadCheck", deadCheck);
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (!deadCheck)
        {
            //Jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                //GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                Debug.Log(GetComponent<Rigidbody2D>().velocity);
                //Debug.Log(Input.GetAxis("Horizontal"));
            }

            //GetComponent<Rigidbody2D>().velocity.y

            //RIght && left
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            //else 
            //{
            //    GetComponent<Rigidbody2D>().position = GameObject.Find("exorcist").transform.position;
            //}

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
                Debug.Log("test");
				Debug.Log("test2");
            }

            //Shooting
           if (Input.GetKeyDown(KeyCode.X))
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                anim.Play("exAtk2");
            }
        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }
}
