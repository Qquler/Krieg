using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI : MonoBehaviour
{
 
    public float speed1 = 4f;
    public float speed2 = 6f;
    public Transform target;
    Shooter shooter;

    public float distantion;
    // Start is called before the first frame update
    void Start()
    {
        shooter = this.GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.position;
       
        distantion = Vector3.Distance(transform.position, target.position);
        //Vector3.Distance();

        if (distantion < 0f)
        {
           // GetComponent<Shooter>().enabled = true;
            Vector3 direction = transform.position - target.position;

            // Нормализация вектора направления
            direction.Normalize();

            // Перемещение объекта
            transform.position += direction * speed2 * Time.deltaTime;
        }
        else if (distantion > 6f)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
            if (distantion > 8f)
            {
              
                shooter.enabled = false;
            }
            else
            {
               
                shooter.enabled = true;
            }
        }
        print(distantion);
        
    }
  
}
