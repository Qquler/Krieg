using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Las : MonoBehaviour
{
    public Vector3 direction = Vector3.right; // ����������� ����������
    public float speed = 1f; // �������� ����������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ����������� ������� ������� � ��������� �����������
        Vector3 scaleChange = direction.normalized * speed * Time.deltaTime;
        transform.localScale += scaleChange;
    }
}
