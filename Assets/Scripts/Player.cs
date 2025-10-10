using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private GameObject posTomb;
    private bool toEnableActivityAfterTomb;


    [SerializeField] GameObject lvlController;
    public float waitTime = 1f;
    public float waitTimeCharge = 0.2f;
    public float waitTimeCharge1 = 1f;
    //bool canBeat = true;
    //чел, нейроликтер - руина
    public Rigidbody2D rb;
    public Animator animator;
    public FireController fc;
    public float speed;
    public float runspeed;
    public float jumpHeight;
    public bool canBeat = true;
    public bool canCharge = true;
    public bool canCharge1 = true;
    public int fullHP = 100;
    [SerializeField] private int curHP;
    private bool canMove = true;
    
    //public TMP_Text HPText;
    //[SerializeField] AudioController AudioController;

    //public Transform groundCheck;
   // bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        curHP = fullHP;
        rb = GetComponent<Rigidbody2D>();
        GameObject plfam = this.transform.Find("PlayerForAnim").gameObject;
        animator = plfam.GetComponent<Animator>();
        fc = GetComponent<FireController>();
        //HPText.text = curHP.ToString() + " / " + fullHP.ToString();     //ТОЖЕ НУЖНО
    }

    
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
        if (this.CurHP() <= 0)
        {
            lvlController.GetComponent<LevelController>().Lose();
        }
        

        if(posTomb != null)
        {
            //Debug.Log("yes");
            toEnableActivityAfterTomb = true;
            this.GetComponent<FireController>().CanShoot(false);
            this.CanMove(false);
            this.rb.simulated = false;
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            bool t = Input.GetKey(KeyCode.Space);
            //Debug.Log(h.ToString() + v.ToString() + t.ToString());
            if(Mathf.Abs(v) > 0.1 || Mathf.Abs(h) > 0.1 || t)
            {
                //Debug.Log("yes");
                posTomb.GetComponent<TombScript>().LeaveTombOutsideF();
            }
        }

        if(posTomb == null && toEnableActivityAfterTomb)
        {
            toEnableActivityAfterTomb = false;
            this.GetComponent<FireController>().CanShoot(true);
            this.CanMove(true);
            this.rb.simulated = true;
        }
        

       
        if (canMove)
        {
            Mooving();
        }
    }
    //void CheckGround()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);

    //    isGrounded = colliders.Length > 1;
    //}
    void Mooving()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (Mathf.Abs(v) < 0.1)
        {
            v = 0f;
        }
        if (Mathf.Abs(h) < 0.1)
        {
            h = 0f;
        }
        var direction = new Vector2(h, v);
        if (canCharge == true)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                canCharge1 = false;
                StartCoroutine(WaitingCharge());
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.MovePosition(rb.position + direction.normalized * (runspeed) * Mathf.Sqrt(Time.deltaTime));
                    //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed + 2), rb.velocity.y);
                    //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed + 2));
                }
                else
                {
                    rb.MovePosition(rb.position + direction.normalized * (speed) * Mathf.Sqrt(Time.deltaTime));
                    //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
                    //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed);
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) && canCharge1 == true)
            {
                rb.MovePosition(rb.position + direction.normalized * (runspeed) * Mathf.Sqrt(Time.deltaTime));
                //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed + 2), rb.velocity.y);
                //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed + 2));
            }
            else if (canCharge1 == true)
            {
                rb.MovePosition(rb.position + direction.normalized * (speed) * Mathf.Sqrt(Time.deltaTime));
                //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
                //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed);
            }
            //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed), rb.velocity.y);            //Раскомментировать, если понадобится стан после рывка
            //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed));
        }
    }
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
    public float CurHP()
    {
        return curHP;

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
    public void PosTomb(GameObject i)
    {
        posTomb = i;
    }    public void CanMove(bool i)
    {
        canMove = i;
    }
    IEnumerator Waiting()
    {
        canBeat = true;
        yield return new WaitForSeconds(waitTime); //строка ожидания
        canBeat = true;
    }
    IEnumerator WaitingCharge()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (Mathf.Abs(v) < 0.1)
        {
            v = 0f;
        }
        if (Mathf.Abs(h) < 0.1)
        {
            h = 0f;
        }
        var direction = new Vector2(h, v);
        rb.MovePosition(rb.position + direction.normalized * (jumpHeight) * Mathf.Sqrt(Time.deltaTime)*waitTimeCharge);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed + 8), rb.velocity.y);
        //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (speed + 8));

        yield return new WaitForSeconds(waitTimeCharge); //строка ожидания
        canCharge = false;
        canCharge1 = true;
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