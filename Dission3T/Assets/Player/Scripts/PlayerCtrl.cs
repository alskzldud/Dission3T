using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Vector3 dir; //�̵� ����
    public float MSpeed = 5; //�̵� �ӵ�
    public float RSpeed = 1000; //ȸ�� �ӵ�

    void Start()
    {
        
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal"); //���� ����Ű �Է�
        dir.z = Input.GetAxis("Vertical"); //���� ����Ű �Է�
        //�̵� �ӵ� ����
        if (dir.magnitude > 1)
            dir.Normalize();

        float len = MSpeed * Time.deltaTime; //�̵� �Ÿ� ���
        transform.Translate(dir * len); //dir �������� len ��ŭ �̵�

        float rotX = Input.GetAxis("Mouse X"); //���콺 ���� �̵�

        float degX = rotX * RSpeed * Time.deltaTime; //ȸ�� ����
        transform.Rotate(0, degX, 0); //x�� �������� degY��ŭ y�� �������� degX��ŭ ȸ��

        
    }
}
