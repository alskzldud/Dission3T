using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    float mx = 0;

    void Update()
    {
        float x = Input.GetAxis("Mouse X"); //���콺 �¿� �Է�
        mx += x * rotSpeed * Time.deltaTime; //���콺 ȸ���� ����

        transform.eulerAngles = new Vector3(0, mx, 0); //��ü ȸ��
    }
}
