using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextUI : MonoBehaviour
{
    //패널 게임 오브젝트
    public GameObject Panel1;
    //음료수냉장고
    public GameObject Panel2;
    //널브러진 과자
    public GameObject Panel3;

    void OnTriggerEnter (Collider col)
    {
        //플레이어가 방문과 충돌하면
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI 활성화
            Panel1.SetActive(true);
            //2초 후에 비활성화
            Invoke("False", 2.0f);

        }
        
        //플레이어가 음료수냉장고와 충돌하면
        if (col.gameObject.tag == "DrinkR")
        {
            //Text UI 활성화
            Panel2.SetActive(true);
            //2초 후에 비활성화
            Invoke("False", 2.0f);
        }
        //플레이어가 과자와 충돌하면
        if (col.gameObject.tag == "Snack")
        {
            //Text UI 활성화
            Panel3.SetActive(true);
            //2초 후에 비활성화
            Invoke("False", 2.0f);
        }
    }

    void False()
    {
        //Text UI 2초 후에 비활성화시키는 함수
        Panel1.SetActive(false);
        //Text UI 2초 후에 비활성화시키는 함수
        Panel2.SetActive(false);
        //Text UI 2초 후에 비활성화시키는 함수
        Panel3.SetActive(false);
    }
}

