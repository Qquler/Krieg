using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float speed = 4f;
    public Transform target;
    [SerializeField] private float distanceOfview = 10000f;
    [SerializeField] private float distanceOfmoving = 0f;
    [SerializeField] bool isPlayerVisible;
    private Vector3 newPositio;
    private float distantion;
    void Start()
    {
        
    }
    public bool isplayervisible()
    {
        return isPlayerVisible;
    }

    void Update()
    {
        RaycastHit2D hit;
        Vector2 directionToPlayer = (target.position - transform.position);
        directionToPlayer.Normalize();
        hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceOfview);

        Debug.DrawRay(transform.position, directionToPlayer * distanceOfview);
        if (hit != null)
        {
            //Debug.Log("FF");

            if (hit.collider.CompareTag("Player"))
            {
                isPlayerVisible = true;
                newPositio = target.position;
                Debug.Log('T');
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                isPlayerVisible = false;
            }
        }
        distantion = Vector3.Distance(transform.position, newPositio);
        //newPositio = target.position;
        //newPositio.z += 0;
        if (isplayervisible())
        {
            if (distantion < 0f)
            {
                // GetComponent<Shooter>().enabled = true;
                Vector3 direction = transform.position - target.position;

                // Нормализация вектора направления
                direction.Normalize();

                //// Перемещение объекта
                //transform.position += direction * speed * Time.deltaTime;
            }
            else if (distantion > distanceOfmoving)
            {

                transform.position = Vector3.MoveTowards(transform.position, newPositio, speed * Time.deltaTime);

            }
        }
        else
        {

            if (distantion != 0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPositio, speed * Time.deltaTime);
            }
         
        

        }


        //print(distantion);

    }
    public Vector3 getTarget()
    {
        return newPositio;
    }
    //transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    
}
