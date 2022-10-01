using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3; //�̵� �ӵ�
    Vector3 dir; //�̵� ����
    void Start()
    {
        
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal"); //���� ����Ű �Է�
        dir.z = Input.GetAxis("Vertical"); //���� ����Ű �Է�

        //��� �̵� ���⿡ ���� �ӵ��� �����ϰ� ����
        if (dir.magnitude > 1) //������ ���̰� 1���� ũ�ٸ�
            dir.Normalize(); //������ ���̸� 1�� ����

        float len = speed * Time.deltaTime; //�̵� �Ÿ� ���
        transform.Translate(dir * len); //dir �������� len��ŭ �̵�
    }
}
