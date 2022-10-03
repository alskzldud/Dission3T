using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Vector3 dir; //이동 방향
    public float MSpeed = 5; //이동 속도
    public float RSpeed = 1000; //회전 속도

    void Start()
    {
        
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal"); //수평 방향키 입력
        dir.z = Input.GetAxis("Vertical"); //수직 방향키 입력
        //이동 속도 조절
        if (dir.magnitude > 1)
            dir.Normalize();

        float len = MSpeed * Time.deltaTime; //이동 거리 계산
        transform.Translate(dir * len); //dir 방향으로 len 만큼 이동

        float rotX = Input.GetAxis("Mouse X"); //마우스 수평 이동
        //float rotY = Input.GetAxis("Mouse Y"); 

        float degX = rotX * RSpeed * Time.deltaTime; //회전 각도
       // float degY = rotY * RSpeed * Time.deltaTime;
        transform.Rotate(0, degX, 0); //x축 기준으로 degY만큼 y축 기준으로 degX만큼 회전
        

        
    }
}
