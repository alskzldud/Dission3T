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
    //���� �ȳ� UI
    public GameObject Panel4;
    public GameObject superenter1;
    public GameObject superenter2;
    public GameObject Enter;

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
            //����� ���� ũ��
            tvsound.volume=1.0f;
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
        //���� �ȳ� UI
        if (col.gameObject.tag=="SuperEnter")
        {
            //�÷��̾� �̵� �ӵ� 0
            GameObject.Find("Player").GetComponent<PlayerMove>().moveSpeed = 0;
            //�ȳ� UI Ȱ��ȭ
            Panel4.SetActive(true);
            superenter1.SetActive(true);

            Invoke("SuperEnter1OFF", 2f);
            Invoke("SuperEnter2ON", 2.2f);

            //�ǳ� ����
            Destroy(Panel4, 4f);
            Destroy(Enter, 4f);
            //�÷��̾� �̵� �ӵ� ���󺹱�
            Invoke("MoveSpeed", 4.2f);
        }
    }

    void SuperEnter1OFF()
    {
        superenter1.SetActive(false);
    }
    void SuperEnter2ON()
    {
        superenter2.SetActive(true);
    }
    void MoveSpeed()
    {
        //�÷��̾� �̵� �ӵ� 0
        GameObject.Find("Player").GetComponent<PlayerMove>().moveSpeed = 5;
    }

    void OnTriggerExit(Collider col)
    {
        //�÷��̾ �湮�� �浹�ϸ�
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
            Panel1.SetActive(false);
            //����� ���Ұ�
            tvsound.volume = 0.0f;
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

