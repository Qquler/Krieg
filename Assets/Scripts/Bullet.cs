using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] GameObject lvlController;
    public Transform bulletPoint;
    public float sped;
    public float liveTime;
    public int damage;
    void Start()
    {
        Destroy(gameObject, liveTime);
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
            player.ChangeHP(damage);
            // timer = 90;

            if (player.curHP <= 0)
            {
                lvlController.GetComponent<LevelController>().Lose();
            }
            Destroy(this.gameObject);
        }
         Destroy(this.gameObject);
    }
    
}


