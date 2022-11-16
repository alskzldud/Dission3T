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
<<<<<<< Updated upstream
    
=======

    Vector3 drawertarget1 = new Vector3(5.312063f, 0.9918178f, 42.52337f);
    Vector3 drawertarget2 = new Vector3(5.312063f, 0.9918178f, 42.10291f);

    bool open = false;
    bool ClickDelay = true;
    int First = 0;

>>>>>>> Stashed changes
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

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "서랍")
                {
                    Debug.Log("서랍을 클릭함");
                    if (hit.collider.gameObject.transform.position.z > 0.01 && hit.collider.gameObject.transform.position.z <= 0.14)
                    {
                        hit.collider.gameObject.transform.Translate(0, 0, 0.7f);
                        Debug.Log(hit.collider.gameObject.transform.position.z);
                    }
                    else if(hit.collider.gameObject.transform.position.z > 0.14 && hit.collider.gameObject.transform.position.z < 0.2)
                    {
                        hit.collider.gameObject.transform.Translate(0, 0, -0.7f);
                    }
<<<<<<< Updated upstream
=======

                    First++;
                    StartCoroutine(WaitForIt());

                   // StartCoroutine(hit.collider.GetComponent<TestScript>().StartMove());
>>>>>>> Stashed changes
                }
            }
        } 
        else
        {
<<<<<<< Updated upstream
            center.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
=======
            //center.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.tag == "서랍" && open)
            {
                Debug.Log("서랍을 클릭함");

                hit.collider.GetComponent<TestScript>().DrawerMove();
            }
            else if (hit.collider.tag == "서랍" && !open && !ClickDelay)
            {
                hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, drawertarget2, 0.05f);
            }
>>>>>>> Stashed changes
        }

        if (Input.GetButton("Interaction")) // 상호작용
        {
            if (Physics.Raycast(ray, out hit)) // Ray bumped with object
            {
                Debug.Log("충돌 중"); 

                if (hit.collider.tag == "온도조절기1") // is Right thermometer?
                {
                    Debug.Log("오른쪽 온도조절기와 충돌 중");
                    hand1 = GameObject.FindWithTag("hand1");
                    hand1.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                    hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                }
                else if (hit.collider.tag == "온도조절기2") // is Left thermometer?
                {
                    Debug.Log("왼쪽 온도조절기와 충돌 중");
                    hand2 = GameObject.FindWithTag("hand2");
                    hand2.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                    hit.collider.gameObject.transform.Rotate(Vector3.up * 50 * Time.deltaTime);
                }
            }
            else
            {
                Debug.Log("충돌안함");
            }
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // fasten cursor on center
    }
<<<<<<< Updated upstream
=======

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.3f);
        open = !open;
    }
>>>>>>> Stashed changes
}


