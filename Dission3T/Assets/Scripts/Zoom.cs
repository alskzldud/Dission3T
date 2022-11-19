using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    private Vector3 ScreenCenter;
    GameObject point;
    GameObject mag;

    GameObject zoomTarget;

    public Camera zoomC;

    bool zoom = false;

    Vector3 originP;
    Vector3 originR;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        point = GameObject.FindWithTag("Center"); // ����Ʈ �±׷� ã��
        mag = GameObject.FindWithTag("Mag"); // ������ �±׷� ã��
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); // �޾� ī�޶� �߾ӿ� ���� ���

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.tag == "zoomTarget") // ray �浹�� ������Ʈ�� �±װ� ��Ÿ���̸�
            {
                zoomTarget = hit.collider.gameObject; // ��Ÿ�ٿ� �浹�� ������Ʈ ����

                point.GetComponent<Image>().color = new Color(0, 0, 0, 0); // point �� ���̰�
                mag.GetComponent<Image>().color = new Color(255, 255, 255, 255); // ������ ���̰�

                if (Input.GetMouseButtonDown(0)) // ���콺 ��Ŭ��
                {
                    originP = zoomTarget.transform.position; // ��Ÿ���� ���� ��ġ ����
                    originR = zoomTarget.transform.rotation.eulerAngles; // ��Ÿ���� ���� ȸ���� ����
                    ZoomFit(zoomTarget); // �� �Լ� ����
                }
            }
            else
            {
                mag.GetComponent<Image>().color = new Color(0, 0, 0, 0); // ������ �� ���̰�
                point.GetComponent<Image>().color = new Color(255, 255, 255, 255); // point ���̰�
            }
        }

        if (zoomC.gameObject.activeSelf == true)
        {
            float mx = Input.GetAxis("Mouse X"); // ���콺 ���� �̵�
            float my = Input.GetAxis("Mouse Y"); // ���콺 ���� �̵�

            float speed = 500f;
            float deg = speed * Time.deltaTime;

            zoomTarget.transform.Rotate(my * deg, -mx * deg, 0); // �� Ÿ���� ȸ�����Ѷ�

            if (Input.GetKeyDown(KeyCode.Escape)) // ESC Ű�� ������
            {
                zoomC.gameObject.SetActive(false); // �� ī�޶� ��Ȱ��ȭ

                zoomTarget.transform.position = originP; // ��Ÿ���� ���� ��ġ��
                zoomTarget.transform.rotation = Quaternion.Euler(originR); // ��Ÿ���� ���� ȸ��������
            }
        }
    }

    void ZoomFit(GameObject go)
    {
        go.transform.position = new Vector3(0, 50f, 0); // ��Ÿ�� �������� ����

        zoomC.gameObject.SetActive(true); // �� ī�޶� Ȱ��ȭ
    }
}