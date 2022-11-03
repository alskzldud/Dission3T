using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCenter : MonoBehaviour
{
    private Vector3 ScreenCenter;
    private GameObject center;

    bool eDown;

    GameObject hand1;
    GameObject hand2;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // fasten cursur on center
        center = GameObject.Find("Center");
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        
    }

    void Update()
    {

        GetInput();

        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) // searching with click
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

            }

            
        } 
        
        else
        {
            center.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }



        if (eDown) //��ȣ�ۿ�
        {
            //hand.transform.Rotate(Vector3.up * 20 * Time.deltaTime);
            Debug.Log("eDown = true");

           
            if (Physics.Raycast(ray, out hit)) // Ray bumped with object
            {
                Debug.Log("�浹 ��");
                if(hit.collider.tag == "�µ�������")//
                {
                    Debug.Log("�µ�������� �浹 ��");

                    if (hit.collider.transform.position.x > -0.183) // is Right thermometer?
                    {
                        Debug.Log("������ �µ�������� �浹 ��");
                        hand1 = GameObject.FindWithTag("hand1");
                        hand1.transform.Rotate(-Vector3.back * 30 * Time.deltaTime);
                        hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                        
                    }
                    else if(hit.collider.transform.position.x < -0.183) // is Left thermometer?
                    {
                        hand2 = GameObject.FindWithTag("hand2");
                        hand2.transform.Rotate(-Vector3.back * 30 * Time.deltaTime);
                        hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                    }
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


