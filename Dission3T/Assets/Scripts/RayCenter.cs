using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCenter : MonoBehaviour
{
    private Vector3 ScreenCenter;
    private GameObject center;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 정중앙에 고정
        center = GameObject.Find("Center");
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) 
        {
            center.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "서랍")
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
        } else
        {
            center.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
