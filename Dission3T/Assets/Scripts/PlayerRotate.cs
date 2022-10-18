using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    float mx = 0;

    void Update()
    {
        float x = Input.GetAxis("Mouse X"); //마우스 좌우 입력
        mx += x * rotSpeed * Time.deltaTime; //마우스 회전값 누적

        transform.eulerAngles = new Vector3(0, mx, 0); //물체 회전
    }
}
