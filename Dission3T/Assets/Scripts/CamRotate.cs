using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    float mx = 0;
    float my = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X"); //���콺 ���� �̵�
        float y = Input.GetAxis("Mouse Y"); //���콺 ���� �̵�

        mx += x * rotSpeed * Time.deltaTime;
        my += y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -45, 45); //�þ� ����

        transform.eulerAngles = new Vector3(-my, mx, 0); //ī�޶� ȸ��
    }
}
