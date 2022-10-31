using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float rotateSpeed = 20f;
    CharacterController cc;
    float gravity = -20f;
    float yVelocity = 0;

    void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //수평 방향키 입력
        float v = Input.GetAxis("Vertical"); //수직 방향키 입력

        //이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        //transform.position += dir * rotateSpeed * Time.deltaTime; //이동 속도에 맞춰 이동

        //중력값 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        //이동 속도에 맞춰서 이동
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
