using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject lvlController;
    int timer = 0;
    public float waitTime = 1f;
    bool canBeat = true;
    public int fullHP = 100;
    public int curHP;
    public int damage;
    //public Rigidbody2D coin; // префаб нашей пули
    //public Transform coinPoint;
    //public int g = 1;
    // Start is called before the first frame update
    void Start()
    {
        curHP = fullHP;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > 0)
        {
            timer -= 1; ;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
       
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        Player player = collision.gameObject.GetComponent<Player>();
    //    player.ChangeHP(15);
    //        if(player.curHP<= 0)
    //        {
    //            lvlController.GetComponent<LevelController>().Lose();
    //        }
    //    }
       
        
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && canBeat==true)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ChangeHP(damage);
           // timer = 90;
            
            if (player.curHP <= 0)
            {
                lvlController.GetComponent<LevelController>().Lose();
            }
            canBeat = false;
            StartCoroutine(Waiting());
        }
    }
    public void ChangeHP(int deltaHP)
    {
        curHP -= deltaHP;
       ////if (curHP <= 0 && g==1) 
       //// {
       ////     Rigidbody2D clone = Instantiate(coin, coinPoint.position, coinPoint.rotation);
       ////     g = 0;
       //// }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime); //строка ожидания
        canBeat = true;
    }
    
}
