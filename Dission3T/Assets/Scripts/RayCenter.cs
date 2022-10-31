using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCenter : MonoBehaviour
{
    private Vector3 ScreenCenter;
    private GameObject center;

    bool eDown;

    public GameObject hand;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� ���߾ӿ� ����
        center = GameObject.Find("Center");
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        
    }

    void Update()
    {

        GetInput();

        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) //Ž��, �� ���� (���� �ڵ����� �ʿ�)
        {
            

            center.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "����")
                {
                    Debug.Log(hit.collider.gameObject.transform.position.z);
                    if (hit.collider.gameObject.transform.position.z <= 12.5)
                    {
                        hit.collider.gameObject.transform.Translate(0, 0, 0.7f);
                    }
                    else
                        hit.collider.gameObject.transform.Translate(0, 0, -0.7f);
                }

                if (hit.collider.tag == "�µ�������")
                {
                    Debug.Log("�µ�������� �浹 ��");
                }
            }

            
        } 
        
        else
        {
            center.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }



        if (eDown) //��ȣ�ۿ�
        {

            Debug.Log("eDown = true");

           
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("�浹 ��");
                if(hit.collider.tag == "�µ�������")
                {
                    Debug.Log("�۵� ��(����)");
                    hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                    hand.transform.Rotate(Vector3.up * 20 * Time.deltaTime);

                }
                else
                {
                    Debug.Log("�۵� ����");
                }
            }
        }


    }


    void GetInput()
    {
        eDown = Input.GetButton("Interaction");
    }
    
}


