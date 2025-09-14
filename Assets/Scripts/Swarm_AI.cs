//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Swarm_AI : MonoBehaviour
//{
//    public float speed = 4f;
//    public Transform target;
//    [SerializeField] private float distanceOfview = 10000f;
//    [SerializeField] private float distanceOfmoving = 0f;
//    private bool isPlayerVisible;
//    private Vector3 newPositio;
//    private float distantion;
//    void Start()
//    {
//        newPositio = transform.position;
//    }
//    public bool isplayervisible()
//    {
//        return isPlayerVisible;
//    }

//    void Update()
//    {
//        RaycastHit2D hit;

//        Vector2 directionToPlayer = (target.position - transform.position);
//        directionToPlayer.Normalize();
//        //Debug.Log(directionToPlayer);
//        //Debug.Log(directionToPlayer);
//        hit = Physics2D.Raycast(transform.position, directionToPlayer, 10000f);

//        Debug.DrawRay(transform.position, directionToPlayer * distanceOfview);
//        if (hit != null)
//        {
//            //Debug.Log("FdF");

//            if (hit.collider.CompareTag("Player"))
//            {
//                isPlayerVisible = true;
//                newPositio = target.position;
//                Debug.Log('T');
//            }
//            else if (hit.collider.CompareTag("Wall"))
//            {
//                isPlayerVisible = false;
//                Debug.Log('w');
//            }
//        }
//        distantion = Vector3.Distance(transform.position, newPositio);
//        //newPositio = target.position;
//        //newPositio.z += 0;
//        //Debug.Log(distantion);
//        if (isplayervisible())
//        {
//            if (distantion < 0f)
//            {
//                // GetComponent<Shooter>().enabled = true;
//                Vector3 direction = transform.position - target.position;

//                // Нормализация вектора направления
//                direction.Normalize();

//                //// Перемещение объекта
//                //transform.position += direction * speed * Time.deltaTime;
//            }
//            else if (distantion > distanceOfmoving)
//            {

//                transform.position = Vector3.MoveTowards(transform.position, newPositio, speed * Time.deltaTime);

//            }
//        }
//        else
//        {

//            if (distantion != 0f)
//            {
//                transform.position = Vector3.MoveTowards(transform.position, newPositio, speed * Time.deltaTime);
//            }



//        }


//        //print(distantion);

//    }
//    public Vector3 getTarget()
//    {
//        return newPositio;
//    }
//    //transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm_AI : MonoBehaviour
{

    public float speed1 = 4f;
    public float speed2 = 6f;

    [SerializeField] private Transform target;
    [SerializeField] private float indent = 0.5f;

    [SerializeField] private float distanceOfview = 10000f;
    [SerializeField] private float distanceOfmoving = 0f; // дистанция дальше которой противник начинает наступать
    private bool isPlayerVisible = false; // нет ли между игроком и врагом стены
    bool isPlayerLost;
    private Vector2 newPosition = Vector2.zero;
    public float distantion;
    private EnemyController cntrl;

    void Start()
    {

        newPosition = transform.position;
        cntrl = this.GetComponent<EnemyController>();

    }
    public bool isplayervisible()
    {
        return isPlayerVisible;
    }
    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit;
        Vector2 directionToPlayer = (target.position - transform.position);
        directionToPlayer.Normalize();
        hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceOfview, 31);

        //Debug.DrawRay(transform.position, getTargetforShooting() * distanceOfview);
        if (hit != null)
        {
            //Debug.Log("FFF");

            if (hit.collider.CompareTag("Player"))
            {
                isPlayerLost = false;
                isPlayerVisible = true;
                newPosition = target.position;
                distantion = Vector2.Distance(transform.position, newPosition);
                //Debug.Log("TT");
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                isPlayerVisible = false;
                distantion = Vector2.Distance(transform.position, newPosition);
                newPosition = Vector3.Lerp(transform.position, newPosition, distantion / indent);
                //Debug.Log("WW");
            }
        }

        //newPositio = target.position;
        //Vector3.Distance();
        if (isplayervisible())
        {

            if (distantion < 0f)
            { 
                Vector3 direction = transform.position - target.position;

                // Нормализация вектора направления
                direction.Normalize();

                // Перемещение объекта
                transform.position = Vector2.MoveTowards(transform.position, direction, speed2 * Time.deltaTime);
            }
            else if (distantion > distanceOfmoving)
            {

                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
                //if (distantion > distanceOfshooting)
                //{

                //    shooter.enabled = false;
                //}
                //else
                //{

                //    shooter.enabled = true;
                //}
            }
        }
        else
        {
            //shooter.enabled = false;
            if (distantion != 0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
            }
            else
            {
                isPlayerLost = true;
            }


        }


        //print(distantion);
        cntrl.SetTraget(newPosition);
    }

    public Vector2 getTarget()
    {
        return newPosition;
    }

}





































//что это мы тут ищем?









































//тут не будет торта







































































// не надейтесь

























































//ладно, вот торт





































//the cake is lie