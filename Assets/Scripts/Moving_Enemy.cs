using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Enemy : MonoBehaviour
    {
    public float speed = 1.5f;
    public Transform point1;
    public Transform point2;

    public float waitTime = 2f;
    bool canGo = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position =
            new Vector3(point1.position.x, point1.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (canGo)
        {
            transform.position =
            Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            if (transform.position == point1.position)
            {
                Transform tmp = point1;
                point1 = point2;
                point2 = tmp;
                canGo = false;
                StartCoroutine(Waiting());
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime); //строка ожидания
        canGo = true;
    }
}
