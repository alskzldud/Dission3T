using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextUI : MonoBehaviour
{
    //�г� ���� ������Ʈ
    public GameObject Panel1;
    //����������
    public GameObject Panel2;

    void OnTriggerEnter (Collider col)
    {
        //�÷��̾ �湮�� �浹�ϸ�
        if (col.gameObject.tag == "RoomDoor")
        {
            //Text UI Ȱ��ȭ
            Panel1.SetActive(true);
            //2�� �Ŀ� ��Ȱ��ȭ
            Invoke("False", 2.0f);

        }
        
        //�÷��̾ ����������� �浹�ϸ�
        if (col.gameObject.tag == "DrinkR")
        {
            //Text UI Ȱ��ȭ
            Panel2.SetActive(true);
            //2�� �Ŀ� ��Ȱ��ȭ
            Invoke("False", 2.0f);
        }
    }

    void False()
    {
        //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
        Panel1.SetActive(false);
        //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
        Panel2.SetActive(false);
    }
}

