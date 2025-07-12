//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HealthBar : MonoBehaviour
//{
//    float maxHp;
//    float curHp;
//    public GameObject mob;
//    float hpBarLen;
//    float startScale;
//    float curScale;
//    float YScale;

//    void Start()
//    {
//        maxHp = mob.GetComponent<Player>().fullHP;
//        startScale = transform.localScale.x;
//        YScale = transform.localScale.y;
//    }
//    void Update()
//    {
//        curHp = mob.CurHP();
//        hpBarLen = curHp / maxHp;

//        if (curHp >= 0)
//        {
//            curScale = curHp * startScale / maxHp;
//            transform.localScale = new Vector3(curScale, YScale, 1);
//        }
//        else
//        {
//            curScale = 0;
//            transform.localScale = new Vector3(curScale, YScale, 1);
//        }
//    }


//}
