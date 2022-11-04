using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextUI : MonoBehaviour
{
    //패널 게임 오브젝트
    public GameObject panel;


    void OnTriggerEnter (Collider col)
    {
        //플레이어가 방문과 충돌하면
        if (col.gameObject.tag == "Roomdoor")
        {
            //Text UI 활성화
            panel.SetActive(true);
            //2초 후에 비활성화
            Invoke("False", 2.0f);
            print("충돌");
        }
    }

    void False()
    {
        //Text UI 2초 후에 비활성화시키는 함수
        panel.SetActive(false);
    }
}

