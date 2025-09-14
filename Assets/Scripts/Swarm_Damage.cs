using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm_Damage : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private bool isPlayer = true;
    [SerializeField] private float waitTime = 1f;
    private bool canBeat = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && canBeat == true && isPlayer)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.ChangeHP(damage);
            // timer = 90;


            canBeat = false;
            StartCoroutine(Waiting());
        }
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime); //строка ожидания
        canBeat = true;
    }
}
