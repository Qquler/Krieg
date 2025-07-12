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
    public float angle = 45;
    void Start()
    {
        //shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        StartCoroutine(Shooting());
        
    }
    private void Update()
    {
        //Debug.Log();
        if (g==1)
        {
            Fire();
            g = 0;
            StartCoroutine(Shooting());
        }
       
    }
    // Update is called once per frame
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShoot);
        g = 1;
        
        //StartCoroutine(Shooting());

    }
    void Fire()
    {
        Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation);   // третье, которое rotation       //Quaternion.Euler(gunPoint.rotation.x, gunPoint.rotation.y, gunPoint.rotation.z));
        //clone.velocity = transform.TransformDirection(gunPoint. * speed);
        //clone.transform.right = gunPoint.right;

    }
}
