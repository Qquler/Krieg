using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody2D bullet;
    public Transform gunPoint;
    private AudioPlayer au;
    [SerializeField] private AudioClip LasGun_Shoot;
    [SerializeField] private float volume = 1;
    [SerializeField] private int damage = 15;
    [SerializeField] private int timeBeat = 2;
    public float g = 0;
    //public Transform shoot;
    public float timeShoot = 2f;
    public float angle = 45;
    private int beat = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && beat == 1)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ChangeHP(damage);
            // timer = 90;


            beat = 0;
            StartCoroutine(Waiting());
        }
    }

    void Start()
    {
        //shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        au = GetComponent<AudioPlayer>();
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
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(timeBeat);
    beat = 1;
        
        //StartCoroutine(Shooting());

    }
void Fire()
    {
        au.PlayAudio(LasGun_Shoot, volume);
        Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation);   // третье, которое rotation       //Quaternion.Euler(gunPoint.rotation.x, gunPoint.rotation.y, gunPoint.rotation.z));
        //clone.velocity = transform.TransformDirection(gunPoint. * speed);
        //clone.transform.right = gunPoint.right;

    }
}
