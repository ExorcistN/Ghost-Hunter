using UnityEngine;
using System.Collections;

public class HurtPlayerControl2 : MonoBehaviour {

    public int damageToGive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealthManager2.HurtPlayer(damageToGive);
            //Debug.Log("test");
        }

    }
}
