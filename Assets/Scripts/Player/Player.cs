
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public float waitTime = 1f;
    public float waitTimeCharge = 0.2f;
    public float waitTimeCharge1 = 1f;
    //bool canBeat = true;

    Rigidbody2D rb;
    Animator animator;
    public float metrics;
    public float speed;
    public float runspeed;
    public bool isPlayer;
    public float jumpHeight;
    public bool canBeat = true;
    public bool canCharge = true;
    public int fullHP = 100;
    public int curHP;
    //public TMP_Text HPText;
    //[SerializeField] AudioController AudioController;

    public Transform groundCheck;
   // bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        curHP = fullHP;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //HPText.text = curHP.ToString() + " / " + fullHP.ToString();     //ТОЖЕ НУЖНО
    }

    // Update is called once per frame
    void Update()
    {
    //  Flip(); //Надо вернуть //// Не надо вернуть


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        //}
        //CheckGround();

        //if (Input.GetKey(KeyCode.LeftControl) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        //{
        //    animator.SetInteger("State", 2);
        //    //speed = speed + 10;
        //}
        //else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)                                          ////АНИМАЦИИ
        //{
        //    animator.SetInteger("State", 0);
        //}
        //else
        //{
        //    animator.SetInteger("State", 1);
        //}
    }
    private void FixedUpdate()
    {
        if (canCharge == true) 
        { 
        
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(WaitingCharge());
            
            }
            else
            {
                float movment = speed;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    movment = runspeed;
                }
                    float fs = Mathf.Sqrt(Input.GetAxis("Horizontal") * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * Input.GetAxis("Vertical"));
                    if(fs == 0)
                    {
                        fs = 1;
                    }
                    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (movment) / fs, rb.velocity.y);
                    rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (movment) / fs);

                    metrics = fs;
                    //rb.velocity = new Vector2(rb.velocity.x, );
                
                
            }
        }
        else
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed), rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed));
        }
    }
    //void CheckGround()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);

    //    isGrounded = colliders.Length > 1;
    //}
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void ChangeHP (int deltaHP)
    {
        if (canBeat == true)
        {
            curHP -= deltaHP;
            // print(curHP);
            //HPText.text = curHP.ToString() + " / " + fullHP.ToString();    //НУЖНО, это полоска хп
            //AudioController.PlaySound();
            StartCoroutine(Waiting());
        }
        
    }
    public void ChangeImageHP()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Waiting()
    {
        canBeat = true;
        yield return new WaitForSeconds(waitTime); //строка ожидания
        canBeat = true;
    }
    IEnumerator WaitingCharge()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed + 8), rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed + 8));

        yield return new WaitForSeconds(waitTimeCharge); //строка ожидания
        canCharge = false;
        StartCoroutine(WaitingCharge1());
    }
    IEnumerator WaitingCharge1()
    {
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed), rb.velocity.y);
        //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed));

        yield return new WaitForSeconds(waitTimeCharge1); //строка ожидания
        canCharge = true;
    }
} 