using UnityEngine;
using System.Collections;

public class DamageofEnemy2 : MonoBehaviour 
{
    public int damageToGive;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerEnter2D(Collider2D other) //OnTriggerEnter2D ใช้ในเช็คการกระทบกันระหว่างวัตถุหนึ่งกับอีกวัตถุหนึ่งโดยจะมีการใช้เงื่อนไข if ในการเช็คว่าศัตรูกระทบกับผู้เล่นใช่หรือไม่
    {
        if (other.tag == "Player")//ถ้ามีการกระทบกับวัตถุที่มีชื่อแทคว่า player ที่อ้างภายใน unity
        {
            HealthManager2.HurtPlayer(damageToGive);//ก็จะให้ HealthManager2 ไปเรียกใช้ฟังก์ชั่น HurtPlayer และนำค่าจากฟังก์ชั่น HurtPlayer ในตัวแปร damageToGive
            //Debug.Log("test");
        }

    }
}
