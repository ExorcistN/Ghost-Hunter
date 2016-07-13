using UnityEngine;
using System.Collections;

public class PlayControl2 : MonoBehaviour {

    public float movespeed;//ความเร็วในการเคลื่อนที่ในการเดิน
    public float jumpheight;//การเคลื่อนที่ในการกระโดด
    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;//เป็นตัวแปนที่ใช้เช็คว่ามีการกระทบกับวัตถุที่เป็นพื้นหรือไม่
    public Transform firepoint;//จุดที่ปล่อยลูกกระสุนในการโจมตีระยะไกล
    public GameObject bulleta;
    public GameObject MeleeAttackEffect;
    private Animator anim;//ใช้สั่งตัวละครให้ทำงาน
    public float shotDelay;
    private float shotDelayCounter;
	// Use this for initialization
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatIsGround);//ใช้เช็คของตำแหน่งของ ground และรัศมีในการกระทบกันของวัตถุ 

    }
	void Start () 
    {
	     anim = GetComponent<Animator>();//ตัวแปร anim มีการอ่านค่าAnimator สำหรับท่าทางการเคลื่อนที่ของตัวละคร
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
        if (Input.GetKey(KeyCode.RightArrow))//รับค่าจากคียบอร์ดโดยการควบคุมทิศทางของตัวละคร
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);//ให้ขนาดของวัตถุในเวกเตอร์3 มีค่าในแกน x เท่ากับ 1f  มีค่าในแกน y เท่ากับ 1f มีค่าในแกน z เท่ากับ 1f
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
            Instantiate(bulleta,firepoint.position,firepoint.rotation);//มีการสร้างวัตถุที่ชื่อ bulleta โดยเก็บวัตถุไว้ในตำแหน่งfirepoint และมีการกำหนดมุมมองของวัตถุให้กับ firepoint
            anim.Play("exAtk2");//ให้เล่น animator ที่ชื่อ exAtk2 ทำงาน
            shotDelayCounter = shotDelay;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(MeleeAttackEffect, firepoint.position, firepoint.rotation);//มีการสร้างวัตถุที่ชื่อ MeleeAttackEffect โดยเก็บวัตถุไว้ในตำแหน่งfirepoint และมีการกำหนดมุมมองของวัตถุให้กับ firepoint
            anim.Play("exAtk1");//ให้เล่น animator ที่ชื่อ exAtk2 ทำงาน
        }
        
        if(Input.GetKey(KeyCode.Z))//shooting delay
        {
            shotDelayCounter -= Time.deltaTime;
            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(bulleta, firepoint.position, firepoint.rotation);//มีการสร้างวัตถุที่ชื่อ bulleta โดยเก็บวัตถุไว้ในตำแหน่งfirepoint และมีการกำหนดมุมมองของวัตถุให้กับ firepoint
            }
        }
	
	}
}
