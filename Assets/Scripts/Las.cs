using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Las : MonoBehaviour
{
    public Vector3 direction = Vector3.right; // Направление увеличения
    public float speed = 1f; // Скорость увеличения

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Увеличиваем масштаб объекта в выбранном направлении
        Vector3 scaleChange = direction.normalized * speed * Time.deltaTime;
        transform.localScale += scaleChange;
    }
}
