using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float time;
    public float count;
    public GameObject enemy;
    public Transform spawnerr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(this.time);
        GameObject clone = Instantiate(enemy, spawnerr.position, spawnerr.rotation);

        //StartCoroutine(Shooting());

    }
}
