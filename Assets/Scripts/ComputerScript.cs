using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ComputerScript : MonoBehaviour
{
    [SerializeField] private GameObject objj;
    [SerializeField] private float volume = 1f;
    [SerializeField] private bool manyTimes;
     private bool doo = false;
    [SerializeField] public AudioClip activateSound;
     private GameObject act;
    private GameObject dis;
    private GameObject collidr;
    private AudioPlayer aau;


    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        aau = this.GetComponent<AudioPlayer>();
        act = transform.Find("computerAct").gameObject;
        dis = transform.Find("computerDis").gameObject;
        collidr = transform.Find("computerCollider").gameObject;

        //audioSource = collidr.GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Activate(ref GameObject objj)
    {
        if (objj.CompareTag("Door"))
        {
            DoorActivate(ref objj);
        }
        audioSource.PlayOneShot(activateSound, volume);
        //aau.PlayAudio(activateSound, volume);
        dis.GetComponent<SpriteRenderer>().enabled = false;
        act.GetComponent<SpriteRenderer>().enabled = true;
        doo = true;

    }

    void DoorActivate(ref GameObject objj)
    {
        DoorScript obj = objj.GetComponent<DoorScript>();
        obj.AllowToOpen(true);
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("fwefwe");
        //Debug.Log("DA");
        if (collision.gameObject.tag == "Player")
        {
            

            if (Input.GetAxis("MainActionButton") == 1)
            {
                if (!doo || manyTimes)
                {
                    Activate(ref objj);
                }

            }
            


            
                //door.Open();
            
            

        }
    }
}

