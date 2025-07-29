using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MovePoint : MonoBehaviour
{
    
    //bool canBeat = true;

    Rigidbody2D rb;
    public float speed = 6f;
    public float speed1 = 0f;
    public float speed2 = 0f;
    public Transform target;
    Shooter shooter;
    public float distantion;
    public float waitTime1 = 2f;
    private bool stay = false;

    [SerializeField] private float maxDist;
    // Start is called before the first frame update
    void Start()
    {
        shooter = this.GetComponent<Shooter>();
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(Waiting());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        var direction = new Vector2(h, v);
        rb.MovePosition(rb.position + direction.normalized * (speed) * Time.deltaTime);
        if (Mathf.Abs(h) < 0.1f && Mathf.Abs(v) < 0.1f) 
        {
            stay = true;
        }


        Vector3 newPosition = target.position;

        distantion = Vector3.Distance(transform.position, target.position);
        //Vector3.Distance();
      
        if (distantion > maxDist)
        {
            //// GetComponent<Shooter>().enabled = true;
            //Vector3 direction1 = transform.position - target.position;

            //// Нормализация вектора направления
            //direction1.Normalize();

            //// Перемещение объекта
            //transform.position += direction1 * speed2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed2 * Time.deltaTime);
            stay = false;
        }
        else if (distantion > 0f && stay == true)
        {
            stay = false;
           // StartCoroutine(Waiting());
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);

        }

    }
    //IEnumerator Waiting()
    //{
    //    yield return new WaitForSeconds(waitTime1); //строка ожидания
    //    stay = true;
    //}



}
