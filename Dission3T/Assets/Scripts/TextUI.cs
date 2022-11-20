using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextUI : MonoBehaviour
{
    //Tv소리
    public GameObject Panel1;
    //Tv소리 오디오 소스
    public AudioSource tvsound;
    //음료수냉장고
    public GameObject Panel2;
    //널브러진 과자
    public GameObject Panel3;

    void Start()
    {
        AudioSource tvsound = gameObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter (Collider col)
    {
        //플레이어가 방문과 충돌하면
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI 활성화
            Panel1.SetActive(true);
            //오디오 볼륨 크게
            tvsound.volume=1.0f;
        }
        //플레이어가 음료수냉장고와 충돌하면
        if (col.gameObject.tag == "DrinkR")
        {
            //Text UI 활성화
            Panel2.SetActive(true);
        }
        //플레이어가 과자와 충돌하면
        if (col.gameObject.tag == "Snack")
        {
            //Text UI 활성화
            Panel3.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        //플레이어가 방문과 충돌하면
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI 2초 후에 비활성화시키는 함수
            Panel1.SetActive(false);
            //오디오 음소거
            tvsound.volume = 0.0f;
        }
        //플레이어가 음료수냉장고와 충돌하면
        if (col.gameObject.tag == "DrinkR")
        {
            //Text UI 2초 후에 비활성화시키는 함수
            Panel2.SetActive(false);
        }
        //플레이어가 과자와 충돌하면
        if (col.gameObject.tag == "Snack")
        {
            //Text UI 2초 후에 비활성화시키는 함수
            Panel3.SetActive(false);
        }
    }

}

