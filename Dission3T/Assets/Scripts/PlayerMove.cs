using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotateSpeed = 20;
    CharacterController cc;
    float gravity = -20f;
    float yVelocity = 0;

    void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //���� ����Ű �Է�
        float v = Input.GetAxis("Vertical"); //���� ����Ű �Է�

        //�̵� ���� ����
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        //transform.position += dir * rotateSpeed * Time.deltaTime; //�̵� �ӵ��� ���� �̵�

        //�߷°� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //�̵� �ӵ��� ���缭 �̵�
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
