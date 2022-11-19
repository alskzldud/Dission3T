using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextUI : MonoBehaviour
{
    //Tv�Ҹ�
    public GameObject Panel1;
    //Tv�Ҹ� ����� �ҽ�
    public AudioSource tvsound;
    //����������
    public GameObject Panel2;
    //�κ귯�� ����
    public GameObject Panel3;

    void Start()
    {
        AudioSource tvsound = gameObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter (Collider col)
    {
        //�÷��̾ �湮�� �浹�ϸ�
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI Ȱ��ȭ
            Panel1.SetActive(true);
            //����� ���
            tvsound.Play();
        }
        //�÷��̾ ����������� �浹�ϸ�
        if (col.gameObject.tag == "DrinkR")
        {
            //Text UI Ȱ��ȭ
            Panel2.SetActive(true);
        }
        //�÷��̾ ���ڿ� �浹�ϸ�
        if (col.gameObject.tag == "Snack")
        {
            //Text UI Ȱ��ȭ
            Panel3.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        //�÷��̾ �湮�� �浹�ϸ�
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
            Panel1.SetActive(false);
            //����� ����
            tvsound.Stop();
        }
        //�÷��̾ ����������� �浹�ϸ�
        if (col.gameObject.tag == "DrinkR")
        {
            //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
            Panel2.SetActive(false);
        }
        //�÷��̾ ���ڿ� �浹�ϸ�
        if (col.gameObject.tag == "Snack")
        {
            //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
            Panel3.SetActive(false);
        }
    }

}

