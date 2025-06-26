using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody2D bullet;
    public Transform gunPoint;
    public float g = 0;
    //public Transform shoot;
    public float timeShoot = 2f;
    void Start()
    {
        InvokeRepeating("Fire", 2f, 2f); 
    }
    //private void Update()
    //{
    //    if (g == 1)
    //    {
    //        Fire();
    //        g = 0;
    //        StartCoroutine(Shooting());
    //    }

    //}
    // Update is called once per frame
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShoot);
        g = 1;
        
        //StartCoroutine(Shooting());

    }
    void Fire()
    {
        Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation);
        //clone.velocity = transform.TransformDirection(gunPoint. * speed);
        //clone.transform.right = gunPoint.right;

    }
}
