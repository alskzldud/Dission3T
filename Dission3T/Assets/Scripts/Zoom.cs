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

        point = GameObject.FindWithTag("Center"); // 포인트 태그로 찾기
        mag = GameObject.FindWithTag("Mag"); // 돋보기 태그로 찾기
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter); // 메안 카메라 중앙에 레이 쏘기

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider.tag == "zoomTarget") // ray 충돌한 오브젝트의 태그가 줌타겟이면
            {
                zoomTarget = hit.collider.gameObject; // 줌타겟에 충돌한 오브젝트 저장

                point.GetComponent<Image>().color = new Color(0, 0, 0, 0); // point 안 보이게
                mag.GetComponent<Image>().color = new Color(255, 255, 255, 255); // 돋보기 보이게

                if (Input.GetMouseButtonDown(0)) // 마우스 좌클릭
                {
                    originP = zoomTarget.transform.position; // 줌타겟의 원래 위치 저장
                    originR = zoomTarget.transform.rotation.eulerAngles; // 줌타겟의 원래 회전값 저장
                    ZoomFit(zoomTarget); // 줌 함수 실행
                }
            }
            else
            {
                mag.GetComponent<Image>().color = new Color(0, 0, 0, 0); // 돋보기 안 보이게
                point.GetComponent<Image>().color = new Color(255, 255, 255, 255); // point 보이게
            }
        }

        if (zoomC.gameObject.activeSelf == true)
        {
            float mx = Input.GetAxis("Mouse X"); // 마우스 수평 이동
            float my = Input.GetAxis("Mouse Y"); // 마우스 수직 이동

            float speed = 500f;
            float deg = speed * Time.deltaTime;

            zoomTarget.transform.Rotate(my * deg, -mx * deg, 0); // 줌 타겟을 회전시켜라

            if (Input.GetKeyDown(KeyCode.Escape)) // ESC 키를 누르면
            {
                zoomC.gameObject.SetActive(false); // 줌 카메라 비활성화

                zoomTarget.transform.position = originP; // 줌타겟을 원래 위치로
                zoomTarget.transform.rotation = Quaternion.Euler(originR); // 줌타겟을 원래 회전값으로
            }
        }
    }

    void ZoomFit(GameObject go)
    {
        go.transform.position = new Vector3(0, 50f, 0); // 줌타겟 공중으로 띄우기

        zoomC.gameObject.SetActive(true); // 줌 카메라 활성화
    }
}
