using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] GameObject lvlController;
    [SerializeField] private int damage = 15;
    public Transform bulletPoint;
    public float sped;
    public float g = 1;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void FixedUpdate()
    {
       // rb.AddForce(transform.forward * thrust);
    }
    private void Update()
    {
        this.gameObject.transform.position = Vector3.Lerp(transform.position, bulletPoint.transform.position, sped * Time.deltaTime);
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
         if (!collision.isTrigger && collision.gameObject.tag == "Player" )
         {
            Player player = collision.gameObject.GetComponent<Player>();
            if (g == 1) 
            {
                player.ChangeHP(damage);
              //  player.curHP = 0;                                                ////Œ¡ﬂ«¿“≈À‹ÕŒ »—œŒÀ‹«Œ¬¿“‹ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                g = 0;
                // timer = 90;
            }


            if (player.CurHP() <=0)
            {
                lvlController.GetComponent<LevelController>().Lose();
            }
            Destroy(this.gameObject);
         }
         else if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
         
    }
    
}


