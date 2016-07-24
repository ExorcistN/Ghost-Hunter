using UnityEngine;
using System.Collections;

public class NetCameraControl : MonoBehaviour {

    public NetPlayerControl Nplayer;

    private float MaxLeft=-0.75f;
    public bool isFollowing;

    public float xOffset;
	// Use this for initialization
	void Start () {
        Nplayer = FindObjectOfType<NetPlayerControl>();
        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
        {
            transform.position = new Vector3(Nplayer.transform.position.x + xOffset, transform.position.y, transform.position.z);
        }
        if (Nplayer.transform.position.x < MaxLeft)
        {
            isFollowing = false;
        }
        else
        {
            isFollowing = true;
        }
	}

}
