using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextUI : MonoBehaviour
{
    //�г� ���� ������Ʈ
    public GameObject panel;


    void OnTriggerEnter (Collider col)
    {
        //�÷��̾ �湮�� �浹�ϸ�
        if (col.gameObject.tag == "Roomdoor")
        {
            //Text UI Ȱ��ȭ
            panel.SetActive(true);
            //2�� �Ŀ� ��Ȱ��ȭ
            Invoke("False", 2.0f);
            print("�浹");
        }
    }

    void False()
    {
        //Text UI 2�� �Ŀ� ��Ȱ��ȭ��Ű�� �Լ�
        panel.SetActive(false);
    }
}

