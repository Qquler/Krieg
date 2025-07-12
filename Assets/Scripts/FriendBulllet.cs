using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBullet : MonoBehaviour
{
    public Rigidbody2D coin;
    Rigidbody2D rb;
    // [SerializeField] GameObject lvlController;
    [SerializeField] GameObject lvlController;
    LevelController levelController;
    public Transform bulletPoint;
    public float sped;
    public Transform coinPoint;
    public float liveTime;
    public Vector3 direction = Vector3.right; // Направление увеличения
    public float speed = 1f;
    private float g = 0;
    private float g1 = 1;

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
        if (g == 1)
        {
            //Vector3 scaleChange = direction.normalized * speed * Time.deltaTime;
            //transform.localScale -= scaleChange;
            this.gameObject.transform.position = Vector3.Lerp(transform.position, bulletPoint.transform.position, 0 * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.position = Vector3.Lerp(transform.position, bulletPoint.transform.position, sped * Time.deltaTime);
        }

        this.gameObject.transform.position = Vector3.Lerp(transform.position, bulletPoint.transform.position, sped * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        levelController = lvlController.GetComponent<LevelController>();
        if (!collision.isTrigger && collision.gameObject.tag != "Player" && g1 == 1 && collision.gameObject.tag != "SwarmCollider") 
        {
            g1 = 0;
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.ChangeHP(25);
            // timer = 90;

            if (enemy.curHP <= 0)
            {
                Destroy(collision.gameObject);
                //Rigidbody2D clone = Instantiate(coin, coinPoint.position, coinPoint.rotation);
                //levelController.coinText.text =
                //      (int.Parse(levelController.coinText.text) + 10).ToString();
                //PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 10);


            }

            //g = 1;
            Destroy(this.gameObject);
        }
      // Destroy(this.gameObject);
    }
   
}
