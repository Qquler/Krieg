using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointing_on_Player : MonoBehaviour
{
    //[SerializeField] GameObject lvlController;
    //private SpriteRenderer Spr;
    public float offset;
    public GameObject arm;
    //private Vector3 player;
    //private Shooter_AI_Necron_Behaviour ai;
    int ChAngle;
    public float speed = 100;
    public int angle = 0;
    [SerializeField] public EnemyController cntrl;

    //[SerializeField] private float CheckPeriod = 1f;
    //private float m_LastCheck;


    // Start is called before the first frame update
//    void Start()
//    {
//        m_LastCheck = CheckPeriod;
//} 

    // Update is called once per frame
    void Update()
    {
        //m_LastCheck -= Time.deltaTime;
        //if (m_LastCheck <= 0)
        //{
            //m_LastCheck = CheckPeriod;


            Debug.Log("de");
            ChAngle = Random.Range(-1 * angle, angle);
            //Player player = gameObject<Player>();

            Vector2 target = cntrl.GetTarget();
            Debug.Log(target);
            float rotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

            //transform.rotation = Quaternion.Euler(0f, transform.rotation.y, rotZ * Time.deltaTime * speed + offset);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, transform.rotation.y, (rotZ + offset + ChAngle)), Time.deltaTime * speed);


        //}
    }

}

