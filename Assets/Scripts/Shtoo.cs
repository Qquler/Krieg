using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shtoo : MonoBehaviour
{
    public Transform gunPoint;
    public float offset = 0f;
    int randomInt;    
    public int angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(-30, 30);
    }

    // Update is called once per frame
    void Update()
    {
        print(gunPoint.rotation.z);
        randomInt = Random.Range(-1 * angle, angle);
        transform.rotation = Quaternion.Euler(0f, 0f, randomInt + offset + gunPoint.rotation.z * 180);
    }
}
