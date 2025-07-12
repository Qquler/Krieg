using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAnim : MonoBehaviour
{
    public Vector3 direction = Vector3.right; // Направление увеличения
    public float speed = 1f; // Скорость увеличения
    public float sped = 1;

    void Start()
    {
        Destroy(gameObject, sped);
    }

    void FixedUpdate()
    {
       // rb.AddForce(transform.forward * thrust);
    }
    private void Update()
    {
        Vector3 scaleChange = direction.normalized * speed * Time.deltaTime;
        transform.localScale += scaleChange;
    }
    
    
}


