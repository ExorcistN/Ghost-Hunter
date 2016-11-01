using UnityEngine;
using UnityEngine.UI;
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

    private bool CameraFollowing;

    private bool NdeadCheck;

    public Animator Nanim;

    public Transform NfirePoint;
    public GameObject Nbullet;
    public GameObject NMeleeAttackEffect;

    public float NattackDelay;
    private float NattackDelayCounter = 0;

    [SyncVar]
    public float XscaleI =1f;

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

        //Camera Code
        CameraFollowing = true;
        
        //if (!isLocalPlayer)
        //{
        //    Nanim.runtimeAnimatorController = Resources.Load("exorcist") as RuntimeAnimatorController;
        //}
        if(isLocalPlayer)
        {
            Nanim.runtimeAnimatorController = Resources.Load("exorcist") as RuntimeAnimatorController;
        }
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
        //    Nanim.runtimeAnimatorController = Resources.Load("exorcist") as RuntimeAnimatorController;
            transform.localScale = new Vector3(XscaleI, 1f, 1f);
            //Debug.Log("NotLocal:" + XscaleI);
            return;
        }

        //Debug.Log(this.transform.position.x);
        //Debug.Log(CameraFollowing);

        //Camera Code
        if (CameraFollowing)
        {
            Camera.main.transform.position = new Vector3(this.transform.position.x + 2f, 0.08f, -49.6f);
        }
        if (this.transform.position.x < 0f)
        {
            CameraFollowing = false;
        }
        else
        {
            CameraFollowing = true;
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
                
                //Flip Character to Right
                //OnChangeScale(1f);

                //XscaleI = 1f;
                CmdSetXcale(1f);
                transform.localScale = new Vector3(1f, 1f, 1f);
                Debug.Log("Right_Xscale:" + XscaleI);
            }
            //else 
            //{
            //    GetComponent<Rigidbody2D>().position = GameObject.Find("exorcist").transform.position;
            //}

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-NmoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

                //Flip Character to Right
                //OnChangeScale(-1f);

                //XscaleI = -1f;
                CmdSetXcale(-1f);
                transform.localScale = new Vector3(-1f, 1f, 1f);
                Debug.Log("Left_Xscale:" + XscaleI);
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

        //Debug.Log("InLocal:" + XscaleI);
    }

    //private void OnChangeScale(float updatedXScale)
    //{
    //    XscaleI = updatedXScale;
    //    Debug.Log("Scale:" + XscaleI);
    //}

    [Command]
    public void CmdSetXcale(float myVar)
    {
        XscaleI = myVar;
    }
    //public override void OnStartLocalPlayer()
    //{
    //    //Debug.Log("Onstart");
    //    //base.OnStartLocalPlayer();
    //    //transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    //    //transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(1, true);
    //    //transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(2, true);
    //}
    //public override void PreStartClient()
    //{
    //    //Debug.Log("PreStart");
    //    //base.PreStartClient();
    //    //transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    //    //transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(1, true);
    //    //transform.GetComponent<NetworkAnimator>().SetParameterAutoSend(2, true);
    //}
//    public override void  OnStartLocalPlayer()
//{
//     base.OnStartLocalPlayer();
//     Nanim.runtimeAnimatorController = Resources.Load("exorcist-2") as RuntimeAnimatorController;
//}
    
}

