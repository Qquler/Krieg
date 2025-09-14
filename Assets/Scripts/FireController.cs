using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public bool IsRightHand;
    //[SerializeField] MenuController menuController;    // ýòà ñòðî÷êà äëÿ çâóêà
    //public AudioSource audioSource;         // } Ýòî äëÿ çâóêà ñòðåëüáû
    //public AudioClip sound1;                // }
    private AudioPlayer au;
    [SerializeField] private AudioClip LasGun_Shoot;
    [SerializeField] private float volume = 1;
    private float waitTime1 = 0.75f;
    private float waitTime2 = 0.20f;
    public float reloadTime = 2f;
    public int ammo = 25;
    bool canBeat;
    bool canBeat1;
    //bool canBeat2;
    private bool reloading = false;
    public float speed = 30; // ñêîðîñòü ïóëè
    public Rigidbody2D bulletLas;
    public Rigidbody2D bulletBul;// ïðåôàá íàøåé ïóëè
    public Transform gunPoint; // òî÷êà ðîæäåíèÿ
    public int gun = 1;
    //public int g;
    private float curTimeout;
    // Start is called before the first frame update
    private void Start()
    {
        au = GetComponent<AudioPlayer>();
        canBeat = true;
        canBeat1 = true;
        //canBeat2 = false;
        //PlayerPrefs.GetFloat(menuController.SOUND);      //Ýòà ñòðî÷êà äëÿ çâóêà
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gun = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gun = 2;
        }
        //print(canBeat);
        if (Input.GetKeyDown(KeyCode.R) && reloading == false)
        {
            reloading = true;
            StartCoroutine(Reload());
        }
        if (Input.GetMouseButton(0) && canBeat == true && gun == 1 && ammo > 0 && reloading == false)
        {
            if (canBeat == true)
            {
                Fire();
                ammo -= 1;
                canBeat = false;
                StartCoroutine(Waiting());
            }
        }
        if (Input.GetMouseButton(0) && canBeat1 == true && gun == 2)
        {
            if (canBeat == true)
            {
                Fire1();
                canBeat1 = false;
                StartCoroutine(Waiting1());
            }
        }
        //else if (Input.GetMouseButton(0) && canBeat1 == true && IsRightHand == true)
        //{

        //	if (g == 0)
        //	{
        //		canBeat2 = false;
        //	}
        //	StartCoroutine(Waiting2());
        //	if (Input.GetMouseButton(0) && canBeat2 == true)
        //	{

        //		Fire();
        //		canBeat1 = false;
        //		StartCoroutine(Waiting1());
        //		//canBeat2 = false;
        //		g = 0;
        //	}
        //	else
        //	{
        //		g = 1;
        //	}

        //	canBeat1 = false;




        //}



    }

    void Fire()
    {
      
        au.PlayAudio(LasGun_Shoot, volume);
        Rigidbody2D clone = Instantiate(bulletLas, gunPoint.position, gunPoint.rotation);
        //clone.velocity = transform.TransformDirection(gunPoint. * speed);
        //clone.transform.right = gunPoint.right;
        //PlayAudio(sound1);
    }
    void Fire1()
    {
        Rigidbody2D clone = Instantiate(bulletBul, gunPoint.position, gunPoint.rotation);
        //clone.velocity = transform.TransformDirection(gunPoint. * speed);
        //clone.transform.right = gunPoint.right;
        //PlayAudio(sound1);
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime1); //ñòðîêà îæèäàíèÿ
        canBeat = true;
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime); //ñòðîêà îæèäàíèÿ
        reloading = false;
        ammo = 25;
    }
    IEnumerator Waiting1()
    {
        //ñòðîêà îæèäàíèÿ

        yield return new WaitForSeconds(waitTime2);
        canBeat1 = true;

    }
    //IEnumerator Waiting2()
    //{
    //	//ñòðîêà îæèäàíèÿ

    //	yield return new WaitForSeconds(waitTime2);
    //	canBeat2 = true;

    //}
    //public void PlayAudio(AudioClip audioClip)
    //{
    //	audioSource.PlayOneShot(audioClip);
    //}
    //public void PlaySound()
    //{
    //	PlayAudio(sound1);
    //}
}