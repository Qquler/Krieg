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
    public bool canOpen;

    public AudioClip entrSound;
    [HideInInspector] public bool isOpen = false;
    [SerializeField] private float volume = 1f;
    //Scarab = this.transform.Find("Scarab").gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdý
    private Transform leftSlide;
    private Transform rightSlide;
    private Animator anim;
    private bool isIn = false;
    private bool endEntering = false;
    public float speed;
    public float waitForCloseTime = 0f;
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
        anim.SetBool("Open", false);
    }

    public void Open()
    {
        //!collision.isTrigger &&
        isOpen = true;

        
        StartCoroutine(Opening());

        
        // Update is called once per frame

    }
    public void Activate()
    {
        Open();
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
        //Debug.Log(canOpen);


            if (collision.gameObject.tag == "Player")
            {

                if (Input.GetAxis("MainActionButton") == 1)
                {
                if (canOpen)
                {
                    Open();
                }

                }
            }
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (canOpen)
        {
            if (collision.gameObject.tag == "Player" && isOpen)
            {
                StartCoroutine(WaitingForClose());


            }
        }
    }
    IEnumerator WaitingForClose()
    {
        yield return new WaitForSeconds(waitForCloseTime);
        Close();
    }
    public void AllowToOpen(bool allow)
    {
        canOpen = allow;
    }
}