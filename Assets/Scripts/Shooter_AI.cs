using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI : MonoBehaviour
{

    public float speed1 = 4f;
    public float speed2 = 6f;
 
    public Transform target;
    [SerializeField] private float distanceOfview = 10000f;
    [SerializeField] private float distanceOfshooting = 8f;
    [SerializeField] private float distanceOfmoving = 6f;
    private bool isPlayerVisible = false;

    Shooter shooter;
    Poit_to_Player poit;
    private Vector2 newPosition = Vector3.zero;
    public float distantion;
    // Start is called before the first frame update
    //void Awake()
    //{
    //    newPosition = target.position;
    //}
    void Start()
    {
        shooter = this.GetComponent<Shooter>();
        poit = this.GetComponent<Poit_to_Player>();

    }
    bool isplayervisible()
    {
        return isPlayerVisible;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isPlayerVisible);
        RaycastHit2D hit;
        Vector2 directionToPlayer = (target.position - transform.position);
        directionToPlayer.Normalize();
        hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceOfview);

        Debug.DrawRay(transform.position, directionToPlayer * distanceOfview);
        if (hit != null)
        {
            //Debug.Log("FFF");
           
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerVisible = true;
                newPosition = target.position;
                Debug.Log("TT");
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                isPlayerVisible = false;
            }
        }
        distantion = Vector2.Distance(transform.position, newPosition);
          //newPositio = target.position;
        //Vector3.Distance();
        if (isplayervisible())
        {
            poit.enabled = true;
            shooter.enabled = true;
            if (distantion < 0f)
            {
                // GetComponent<Shooter>().enabled = true;
                Vector3 direction = transform.position - target.position;

                // Нормализация вектора направления
                direction.Normalize();

                // Перемещение объекта
                transform.position += direction * speed2 * Time.deltaTime;
            }
            else if (distantion > distanceOfmoving)
            {

                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
                if (distantion > distanceOfshooting)
                {

                    shooter.enabled = false;
                }
                else
                {

                    shooter.enabled = true;
                }
            }
        }
        else
        {
            shooter.enabled = false;
            if (distantion == 0f)
            {
                poit.enabled = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
            }


        }


        //print(distantion);

    }
    public Vector2 getTarget()
    {
        return newPosition;
    }

}
