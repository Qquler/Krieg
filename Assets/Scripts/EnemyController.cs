using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    

    public int fullHP = 100;
    private int curHP;
    private Vector2 target;




    


    //public Rigidbody2D coin; // префаб нашей пули
    //public Transform coinPoint;
    //public int g = 1;
    // Start is called before the first frame update

    void Start()
    {
        curHP = fullHP;

    } 
    public int GetcurHP()
    {
        //Debug.Log('w');
        //Debug.Log(this.curHP);
        return curHP;
    }
    public Vector2 GetTarget()
    {
        return target;
    }
    public void SetTraget(Vector2 tg)
    {
        target = tg;
    }
    public void checkHp()
    {
        if (GetcurHP() <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void ChangecurHP(int delt)
    {
        curHP = delt;
        checkHp();
    }
    public void ChangeHP(int deltaHP)
    {
        curHP -= deltaHP;
        checkHp();
        //if (curHP <= 0 && g==1) 
        // {
        //     Rigidbody2D clone = Instantiate(coin, coinPoint.position, coinPoint.rotation);
        //     g = 0;
        // }
    }
    // Update is called once per frame

    //    timer -= 1; ;    //Зачем это?
    //}

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


}
