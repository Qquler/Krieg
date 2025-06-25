using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
	public bool IsRightHand;
    [SerializeField] MenuController menuController;
    public AudioSource audioSource;
    public AudioClip sound1;

    private float waitTime1 = 0.75f;
	//private float waitTime2 = 0.75f;

	bool canBeat;
	//bool canBeat1;
	//bool canBeat2;
   
    public float speed = 30; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	//public int g;
	private float curTimeout;
    // Start is called before the first frame update
    private void Start()
    {
		canBeat = true;
		//canBeat1 = true;
		//canBeat2 = false;
        PlayerPrefs.GetFloat(menuController.SOUND);
    }
    void Update()
	{
		if (Input.GetMouseButton(0) && canBeat==true && IsRightHand == false)
		{
			Fire();



			canBeat = false;
			StartCoroutine(Waiting());
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
		Rigidbody2D clone = Instantiate(bullet, gunPoint.position, gunPoint.rotation);
        //clone.velocity = transform.TransformDirection(gunPoint. * speed);
        //clone.transform.right = gunPoint.right;
        PlayAudio(sound1);
    }
	IEnumerator Waiting()
	{
		yield return new WaitForSeconds(waitTime1); //строка ожидания
		canBeat = true;
	}
	//IEnumerator Waiting1()
	//{
	//	 //строка ожидания

	//	yield return new WaitForSeconds(waitTime2);
	//	canBeat1 = true;

	//}
	//IEnumerator Waiting2()
	//{
	//	//строка ожидания

	//	yield return new WaitForSeconds(waitTime2);
	//	canBeat2 = true;

	//}
	public void PlayAudio(AudioClip audioClip)
	{
		audioSource.PlayOneShot(audioClip);
	}
	public void PlaySound()
	{
		PlayAudio(sound1);
	}
}

