using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI_Necron_Behaviour : MonoBehaviour
{

    public float speed1 = 4f;
    public float speed2 = 6f;

    [SerializeField] private Transform target;
    [SerializeField] private float indent = 0.5f;
    [SerializeField] private Transform targetShooting;
    [SerializeField] private float distanceOfview = 10000f;
    [SerializeField] private float distanceOfshooting = 8f;//��� � ��� �������
    [SerializeField] private float distanceOfmoving = 6f; // ��������� ������ ������� ��������� �������� ���������
    private bool isPlayerVisible = false; // ��� �� ����� ������� � ������ �����
    [SerializeField] private float damping = 100; //�������� ��������
    public float offset;
    public GameObject arm;
    public int angle = 0;
    bool isPlayerLost;
    Shooter shooter;
    private Vector2 newPosition = Vector2.zero;
    public float distantion;

    void Start()
    {
        shooter = this.GetComponent<Shooter>();
        newPosition = transform.position;
        //poit = this.GetComponent<Poit_to_Player>();

    }
    public bool isplayervisible()
    {
        return isPlayerVisible;
    }
    // Update is called once per frame
    void Poin_to_player(Vector3 difference, float dampingq)
    {
        int ChAngle;
        ChAngle = Random.Range(-1 * angle, angle);
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, transform.rotation.y, (rotZ + offset + ChAngle)), Time.deltaTime * dampingq);
    }
    void Update()
    {
        if (isPlayerLost)
        {
            Poin_to_player(getTargetforShooting(), 6);
        }
        else
        {
            Poin_to_player(getTargetforShooting(), damping);

        }

        //Debug.Log(isplayervisible());
        RaycastHit2D hit;
        Vector2 directionToPlayer = (target.position - transform.position);
        directionToPlayer.Normalize();
        hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceOfview, 31);

        Debug.DrawRay(transform.position, getTargetforShooting() * distanceOfview);
        if (hit != null)
        {
            //Debug.Log("FFF");

            if (hit.collider.CompareTag("Player"))
            {
                isPlayerLost = false;
                isPlayerVisible = true;
                newPosition = target.position;
                distantion = Vector2.Distance(transform.position, newPosition);
                //Debug.Log("TT");
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                isPlayerVisible = false;
                distantion = Vector2.Distance(transform.position, newPosition);
                newPosition = Vector3.Lerp(transform.position, newPosition, distantion / indent);
            }
        }

        //newPositio = target.position;
        //Vector3.Distance();
        if (isplayervisible())
        {
            //poit.enabled = true;
            shooter.enabled = true;
            if (distantion < 0f)
            {
                // GetComponent<Shooter>().enabled = true;
                Vector3 direction = transform.position - target.position;

                // ������������ ������� �����������
                direction.Normalize();

                // ����������� �������
                transform.position = Vector2.MoveTowards(transform.position, direction, speed2 * Time.deltaTime);
            }
            else if (distantion > distanceOfmoving)
            {

                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
                if (distantion > distanceOfshooting)
                {

                    shooter.enabled = false;
                }
                else
                {

                    shooter.enabled = true;
                }
            }
        }
        else
        {
            shooter.enabled = false;
            if (distantion != 0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed1 * Time.deltaTime);
            }
            else
            {
                isPlayerLost = true;
            }


        }


        //print(distantion);

    }

    public Vector2 getTargetforShooting()
    {
        if (isplayervisible())
        {
            return targetShooting.position - transform.position;
        }
        else
        {
            return (Vector3)newPosition - transform.position;
        }
    }
    public Vector2 getTarget()
    {
        return newPosition;
    }

}





































//��� ��� �� ��� ����?









































//��� �� ����� �����







































































// �� ���������

























































//�����, ��� ����





































//the cake is lie