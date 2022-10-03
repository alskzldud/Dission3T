using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 100;

    void Start()
    {
        
    }

    void Update()
    {
        float rotX = Input.GetAxis("Mouse X"); //���콺 ���� �̵�

        float degX = rotX * speed * Time.deltaTime; //ȸ�� ����
        transform.Rotate(0, degX, 0); //x�� �������� degY��ŭ y�� �������� degX��ŭ ȸ��

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0.0f, 0.0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(0.1f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0.0f, 0.0f);
        }
    }
}
