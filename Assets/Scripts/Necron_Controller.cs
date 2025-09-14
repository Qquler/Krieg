using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Necron_Controller : MonoBehaviour
{
    //int timer = 0;
    public float waitTime = 1f;
    public float waitTimeHeal = 2f;
    bool canBeat = true;
    public int damage;
    public int heal = 10;
    private int g = 0;
    public EnemyController enemyController;
    public Sprite newSprite1;
    public Sprite newSprite;
    public SpriteRenderer spriteRenderer;
    public const int fullHP = 100;
    //public Rigidbody2D bullet;
    //public Transform gunPoint;

    void Awake()
    {
        enemyController = this.GetComponent<EnemyController>();
        if (enemyController.fullHP != fullHP)
        {
            enemyController.fullHP = fullHP;
        }
    }
    void Update()
    {

        //Debug.Log(th.GetcurHP());
        if (enemyController.GetcurHP() <= fullHP / 2)
        {
            spriteRenderer.sprite = newSprite;
        }
        if (enemyController.GetcurHP() > fullHP / 2)
        {
            spriteRenderer.sprite = newSprite1;
        }

        if (enemyController.GetcurHP() < fullHP)
        {
            if (g == 0)
            {
                g = 2;
                StartCoroutine(WaitingHeal());
            }
            else if (g == 1)
            {
                g = 0;
                //Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation);
                this.HealHP(heal);
            }
        }

        //if (timer > 0)
        //{
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && canBeat == true)
    //    {
    //        Player player = collision.gameObject.GetComponent<Player>();
    //        player.ChangeHP(damage);
    //        // timer = 90;


    //        canBeat = false;
    //        StartCoroutine(Waiting());
    //    }
    //}
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;                      // Для смены спрайта использовать эту строчку
    }

    public void HealHP(int deltaHeal)
    {
        if (enemyController.GetcurHP() + deltaHeal > fullHP)
        {
            enemyController.ChangecurHP(fullHP);
        }
        else
        {
            enemyController.ChangecurHP(deltaHeal + enemyController.GetcurHP());
        }


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