using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject lvlController;
    //int timer = 0;
    public float waitTime = 1f;
    public float waitTimeHeal = 2f;
    bool canBeat = true;
    public int fullHP = 100;
    public int curHP;
    public int damage;
    public int heal = 10;
    private int g = 0;

    public Rigidbody2D bullet;
    public Transform gunPoint;


    
    public Sprite newSprite;
    public Sprite newSprite1;
    public SpriteRenderer spriteRenderer;

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
        if (curHP <= fullHP / 2)
            {
                spriteRenderer.sprite = newSprite;
            }
        if (curHP > fullHP / 2)
        {
            spriteRenderer.sprite = newSprite1;
        }
        if (curHP < fullHP)
        {
            if (g == 0)
            {
                g = 2;
                StartCoroutine(WaitingHeal());
            }
            else if (g == 1)
            {
                g = 0;
                Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation);
                this.HealHP(heal);
            }
        }
        if (curHP > fullHP)
        {
            g = 0;
            curHP = fullHP;
        }
        //if (timer > 0)
        //{
        //    timer -= 1; ;    //Зачем это?
        //}
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
            
            if (player.CurHP() <= 0)
            {
                lvlController.GetComponent<LevelController>().Lose();
            }
            canBeat = false;
            StartCoroutine(Waiting());
        }
    }
        void ChangeSprite()
        {
            spriteRenderer.sprite = newSprite;                      // Для смены спрайта использовать эту строчку
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
    public void HealHP(int deltaHeal)
    {
        curHP += deltaHeal;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime); //строка ожидания
        canBeat = true;
    }
    IEnumerator WaitingHeal()
    {
        yield return new WaitForSeconds(waitTimeHeal); //строка ожидания
        g = 1;
    }

}
