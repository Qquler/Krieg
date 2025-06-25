using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poit_to_mouse : MonoBehaviour
    
{
    private SpriteRenderer Spr;
    public float offset;
   public GameObject arm;
    public GameObject gunPoint;
    // Start is called before the first frame update
    void Start()
    {
        Spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {


        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
       
        if (Input.GetAxis("Horizontal") > 0)
        {

        }
        transform.rotation = Quaternion.Euler(0f, transform.rotation.y, rotZ + offset);
        //print(arm.transform.localEulerAngles.z);
        if (arm.transform.localEulerAngles.z < 0 || arm.transform.localEulerAngles.z > 180)
        {
            Flip(false);
            gunPoint.transform.localPosition = new Vector3(-0.23f, gunPoint.transform.localPosition.y, gunPoint.transform.localPosition.z);
        }
        if (arm.transform.localEulerAngles.z > 0 && arm.transform.localEulerAngles.z < 180)
        {

            Flip(false);
            gunPoint.transform.localPosition =new Vector3(0.16f, gunPoint.transform.localPosition.y, gunPoint.transform.localPosition.z);
        }
        void Flip(bool boll)
        {

            Spr.flipX = boll;

        }
    }
   
}
