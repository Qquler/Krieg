using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float speed = 4f;
    public Transform target;

    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 newPosition = target.position;
        //newPosition.z += 0;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
}
