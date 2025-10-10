using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{

    //class polygon
    //{
    //    int a, int b, int c;
    //    public polygon(int a, int b, int c)
    //    {
    //        this.a = a;
    //        this.b = b;
    //        this.c = c;
    //    }
    //}

    private AudioPlayer aau;
    public AudioClip entrSound;
    public bool opn = false;
    public bool isOpen = false;
    [SerializeField] private float volume = 1f;
    //Scarab = this.transform.Find("Scarab").gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdý
    private Transform leftSlide;
    private Transform rightSlide;
    private Animator anim;
    private bool isIn = false;
    private bool endEntering = false;
    public float speed;
    //public float speed1;
    //public float speed2;
    public GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Update()
    //{
    //    if (opn)
    //    {
    //        Open();
    //    }
    //}

    


    void Start()
    {
        
        aau = GetComponent<AudioPlayer>();
        //Debug.Log(aau);
        //aau.PlayAudio(LasGun_Shoot, volume);
        leftSlide = this.transform.Find("LeftSlide");
        rightSlide = this.transform.Find("RightSlide");
     
        anim = GetComponent<Animator>();
        anim.speed = 1f / speed;

    }

    public void Open()
    {
        //!collision.isTrigger &&
        isOpen = true;

        
        StartCoroutine(Opening());

        
        // Update is called once per frame

    }
    
    public void Close()
    {
        //!collision.isTrigger &&
        isOpen = false;


        StartCoroutine(Closing());
        

        // Update is called once per frame

    }
    IEnumerator Opening()
    {

        //Vector3 pr = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);

        anim.SetBool("Open", true);
        yield return new WaitForSeconds(speed);

    }
    IEnumerator Closing()
    {

        //Vector3 pr = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);

        anim.SetBool("Open", false);
        yield return new WaitForSeconds(speed);
  

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
             
            if (Input.GetAxis("MainActionButton") == 1) { 
                Open();
                
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        
                Close();

            
        }
    }
}