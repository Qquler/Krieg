using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Las : MonoBehaviour
{
    [SerializeField] GameObject lvlController;
    LevelController levelController;
    public Vector3 direction = Vector3.right; // Направление увеличения
    public float speed = 1f; // Скорость увеличения
    //private float g = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Увеличиваем масштаб объекта в выбранном направлении
        //if (g == 0)
        //{
            Vector3 scaleChange = direction.normalized * speed * Time.deltaTime;
            transform.localScale += scaleChange;
        //}
        //else if (g == 1)
        //{
        //    Vector3 scaleChange = direction.normalized * speed * Time.deltaTime;
        //    transform.localScale -= scaleChange;
        //}
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        levelController = lvlController.GetComponent<LevelController>();
        if (!collision.isTrigger && collision.gameObject.tag != "Player")
        {
           // g = 1;
        }
    }
}
