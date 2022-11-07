using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCenter : MonoBehaviour
{
    private Vector3 ScreenCenter;
    private GameObject center;

    GameObject hand1;
    GameObject hand2;

    Vector3 drawertarget1 = new Vector3(5.312063f, 0.9918178f, 42.52337f);
    Vector3 drawertarget2 = new Vector3(1.930465f, 0.8712302f, 12.752f);


    bool cDown;

    void Start()
    {
        center = GameObject.Find("Center");
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) // searching with click
        {
            center.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            
            cDown = true;
            StartCoroutine(WaitForIt());
        } 
        else
        {
            center.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (Physics.Raycast(ray, out hit, 100.0f) && cDown)
        {
            if (hit.collider.tag == "����")
            {
                Debug.Log("������ Ŭ����");
                if (hit.collider.gameObject.transform.localPosition.z > 0.9f) // higher drawer open
                {
                    Debug.Log("������ ������ Ŭ����");

                    hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, drawertarget1, 0.05f);
                    //cDown = false;
                    
                }
            }


            else if (hit.collider.gameObject.transform.localPosition.y < 0) // lower drawer open    
            {
                Debug.Log("���� ������ Ŭ����");
                Vector3 velo = Vector3.zero;
                hit.collider.gameObject.transform.position = Vector3.SmoothDamp(hit.collider.gameObject.transform.position, drawertarget2, ref velo, 0.03f);
                cDown = false;
            }

        }
            
        
        if (Input.GetButton("Interaction")) // ��ȣ�ۿ�
        {
            if (Physics.Raycast(ray, out hit)) // Ray bumped with object
            {
                Debug.Log("�浹 ��"); 

                if (hit.collider.tag == "�µ�������1") // is Right thermometer?
                {
                    Debug.Log("������ �µ�������� �浹 ��");
                    hand1 = GameObject.FindWithTag("hand1");
                    hand1.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                    hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                }
                else if (hit.collider.tag == "�µ�������2") // is Left thermometer?
                {
                    Debug.Log("���� �µ�������� �浹 ��");
                    hand2 = GameObject.FindWithTag("hand2");
                    hand2.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                    hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                }
            }
            else
            {
                Debug.Log("�浹����");
            }
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // fasten cursur on center
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.3f);
        cDown = false;
    }

}


