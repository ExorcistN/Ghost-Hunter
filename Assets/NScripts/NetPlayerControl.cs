using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetPlayerControl : NetworkBehaviour
{

    public float NmoveSpeed;
    public float NjumpHeight;

    public Transform NgroundCheck;
    public float NgroundCheckRadius;
    public LayerMask NwhatIsGround;
    private bool Ngrounded;


    private bool NdeadCheck;

    public Animator Nanim;
    public Animator Nanim2;

    public Transform NfirePoint;
    public GameObject Nbullet;
    public GameObject NMeleeAttackEffect;

    public float NattackDelay;
    private float NattackDelayCounter = 0;

    //public Sprite newSprite;


    void FixedUpdate()
    {

        Ngrounded = Physics2D.OverlapCircle(NgroundCheck.position, NgroundCheckRadius, NwhatIsGround);

    }

    // Use this for initialization
    //E:
    void Start()
    {
        Nanim = GetComponent<Animator>();
    }

    public void spawnCharacter()
    {
        NdeadCheck = false;
    }
    public void DelCharacter()
    {
        NdeadCheck = true;
        //Destroy(GetComponent<Rigidbody2D>());
        //Destroy(gameObject, 0.6f);
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            Nanim.runtimeAnimatorController = Resources.Load("exorcist") as RuntimeAnimatorController;
            return;
        }
        Nanim.SetBool("DeadCheck", NdeadCheck);
        Nanim.SetBool("Grounded", Ngrounded);
        Nanim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (!NdeadCheck)
        {
            //Jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) && Ngrounded)
            {
                //GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, NjumpHeight);
                //Debug.Log(Input.GetAxis("Horizontal"));
            }

            //GetComponent<Rigidbody2D>().velocity.y

            //RIght && left

            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(NmoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            //else 
            //{
            //    GetComponent<Rigidbody2D>().position = GameObject.Find("exorcist").transform.position;
            //}

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-NmoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            //Shooting
            if (NattackDelayCounter < 0)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Instantiate(Nbullet, NfirePoint.position, NfirePoint.rotation);
                    Nanim.Play("exAtk2");
                    NattackDelayCounter = NattackDelay;
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Instantiate(NMeleeAttackEffect, NfirePoint.position, NfirePoint.rotation);
                    Nanim.Play("exAtk1");
                    NattackDelayCounter = NattackDelay;
                }
            }
        }
        NattackDelayCounter -= 1;

    }

//    public override void  OnStartLocalPlayer()
//{
//     base.OnStartLocalPlayer();
//     Nanim.runtimeAnimatorController = Resources.Load("exorcist-2") as RuntimeAnimatorController;
//}

}

