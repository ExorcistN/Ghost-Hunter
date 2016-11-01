using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public PlayerControl player;
    private float MaxLeft=0f;
    public bool isFollowing;

    public float xOffset;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControl>();
        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
        {
            this.transform.position = new Vector3(player.transform.position.x + xOffset, transform.position.y, transform.position.z);
        }
        if (player.transform.position.x < MaxLeft)
        {
            isFollowing = false;
        }
        else
        {
            isFollowing = true;
        }
	}
}
