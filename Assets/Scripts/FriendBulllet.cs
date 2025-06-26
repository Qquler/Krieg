using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet : MonoBehaviour
{
    public Rigidbody2D coin;
    Rigidbody2D rb;
    [SerializeField] GameObject lvlController;
    LevelController levelController;
    public Transform bulletPoint;
    public float sped;
    public Transform coinPoint;
    public int damage;
    public float liveTime;

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
    void OnTriggerEnter2D(Collider2D collision)
    {
        levelController = lvlController.GetComponent<LevelController>();
        if (!collision.isTrigger && collision.gameObject.tag != "Player") 
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.ChangeHP(damage);
            // timer = 90;

            if (enemy.curHP <= 0)
            {
                Destroy(collision.gameObject);
                //Rigidbody2D clone = Instantiate(coin, coinPoint.position, coinPoint.rotation);
                //levelController.coinText.text =
                //      (int.Parse(levelController.coinText.text) + 10).ToString();
                //PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);


            } 
           
          

            Destroy(this.gameObject);
        }
      // Destroy(this.gameObject);
    }
   
}
