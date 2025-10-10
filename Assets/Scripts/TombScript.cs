using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class TombScript : MonoBehaviour
{
    private AudioPlayer aau;
    public AudioClip entrSound;
    [SerializeField] private float volume = 1f;
    //Scarab = this.transform.Find("Scarab").gameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdý
    private Transform cap;
    private Transform standPose;
    private Transform standPose1;
    private Transform standPose2;
    private Animator anim;
    private bool isIn = false;
    private bool endEntering = false;
    public float speedOfCap = 1f;
    public float speed;
    public float speed1;
    public float speedl;
    public float delay;
    //public float speed2;
    public GameObject obj;
    public Player player;

    void Start()
    {
        aau = GetComponent<AudioPlayer>();
        //Debug.Log(aau);
        //aau.PlayAudio(LasGun_Shoot, volume);
        cap = this.transform.Find("cap");
        standPose = this.transform.Find("standPose");
        standPose1 = this.transform.Find("standPose1");
        standPose2 = this.transform.Find("standPose2");
        anim = cap.gameObject.GetComponent<Animator>();
        anim.speed = 1f / speedOfCap;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //!collision.isTrigger &&
        if (collision.gameObject.tag == "Player" && !isIn)
        {
            anim.SetBool("Close", false);
            anim.SetBool("Open", false);
            obj = collision.gameObject;
            player = collision.gameObject.GetComponent<Player>();
            
            player.PosTomb(this.gameObject);
            isIn = true;

            endEntering = false;

            StartCoroutine(EnterTomb());

        }
        // Update is called once per frame

    }
    public void LeaveTombOutsideF()
    {
        //Debug.Log(endEntering);
        if (endEntering)
        {
            StartCoroutine(LeaveTomb());
        }
    }
    IEnumerator LeaveTomb()
    {
        
            //Vector3 pr = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);
            Vector3 ps2 = new Vector3(standPose2.position.x, standPose2.position.y, standPose2.position.z);
            Vector3 pr2 = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90);

            anim.SetBool("Open", true);
            yield return new WaitForSeconds(speedOfCap);

            obj.transform.DORotate(pr2, 0);
            obj.transform.DOMove(ps2, speedl);
            yield return new WaitForSeconds(speedl);




            isIn = false;
            player.PosTomb(null);
        
    }
    IEnumerator EnterTomb()
    {
        //obj.transform.position = new Vector3(0, 0, 0);
        //if (isMoving)
        //{
        //    yield break; ///exit if this is still running
        //}
        //float counter = 0;æ

        Vector3 ps = new Vector3(standPose.position.x, standPose.position.y, standPose.position.z);
        Vector3 ss = new Vector3(standPose1.position.x, standPose1.position.y, standPose1.position.z);
        Vector3 pr = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90);
       

        //obj.transform.position = Vector2.MoveTowards(obj.transform.position, ps, 0.5f * Time.deltaTime);

        obj.transform.DOMove(ps, speed);
        obj.transform.DORotate(pr, speed);
        yield return new WaitForSeconds(speed);
        obj.transform.DOMove(ss, speed1);
        aau.PlayAudio(entrSound, volume);
        yield return new WaitForSeconds(speed1 - delay);

        anim.SetBool("Close", true);
        yield return new WaitForSeconds(speedOfCap);
        endEntering = true;
        
    }

}
