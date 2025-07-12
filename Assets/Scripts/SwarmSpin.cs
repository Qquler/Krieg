using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmSpin : MonoBehaviour

{
    public float rotat = 0.5f;
    private float num = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        num += rotat;

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f + num);
        
    }

}
