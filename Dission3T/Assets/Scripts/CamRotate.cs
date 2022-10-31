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
        float x = Input.GetAxis("Mouse X"); //마우스 수평 이동
        float y = Input.GetAxis("Mouse Y"); //마우스 수직 이동

        mx += x * rotSpeed * Time.deltaTime;
        my += y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -65, 65); //시야 제한

        transform.eulerAngles = new Vector3(-my, mx, 0); //카메라 회전
    }
}
