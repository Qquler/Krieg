using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poit_to_Player : MonoBehaviour

{
    private SpriteRenderer Spr;
    public float offset;
    public GameObject arm;
    public GameObject player;

    public bool IsNecron = false;
    int ChAngle;
    public int angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        Spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        ChAngle = Random.Range(-1 * angle, angle);
        //Player player = gameObject<Player>();

        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (IsNecron == true)
        {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.y, rotZ + offset);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.y, rotZ + offset + ChAngle);
        }
        

    }

}
