using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCenter : MonoBehaviour
{
    public Vector3 ScreenCenter;
    private GameObject center;

    GameObject hand1;
    GameObject hand2;

    Vector3 drawertarget1 = new Vector3(5.312063f, 0.9918178f, 42.52337f);
    Vector3 drawertarget2 = new Vector3(5.312063f, 0.9918178f, 42.10291f);

    public GameObject Newspaper1;
    public GameObject Newspaper2;
    public GameObject Newspaper3;
    //신문 조각 획득 UI
    public GameObject Newspaper;
    public GameObject New;
    //노트에 표시
    public GameObject news1;
    public GameObject news2;
    public GameObject news3;

    bool open = false;
    bool ClickDelay = true;
    int First = 0;

    public bool ClearLock;

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
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //center.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                if (hit.collider.tag == "서랍")
                {
                    Debug.Log("서랍이 레이와 부딪힘!");
                    open = !open;

                    if (First > 0)
                    {
                        ClickDelay = !ClickDelay;
                    }

                    First++;
                    StartCoroutine(WaitForIt());

                    // StartCoroutine(hit.collider.GetComponent<TestScript>().StartMove());

                }

                else if (hit.collider.tag == "Rock" && ClearLock == false)
                {
                    hit.collider.GetComponent<RockScript>().RockOpen();
                }
                else if (hit.collider.tag == "LockedDrawer" && ClearLock == true)
                {
                    open = !open;
                    
                }
                
                else if (hit.collider.tag=="Newspaper1")
                {
                    Debug.Log("신문조각 획득");
                    Destroy(Newspaper1);
                    Newspaper.SetActive(true);
                    New.SetActive(true);
                    Invoke("NewsOFF", 1.5f);
                    news1.SetActive(true);

                }
                else if (hit.collider.tag == "Newspaper2")
                {
                    Debug.Log("신문조각 획득");
                    Destroy(Newspaper2);
                    Newspaper.SetActive(true);
                    New.SetActive(true);
                    Invoke("NewsOFF", 1.5f);
                    news2.SetActive(true);
                }
                else if (hit.collider.tag == "Newspaper3")
                {
                    Debug.Log("신문조각 획득");
                    Destroy(Newspaper3);
                    Newspaper.SetActive(true);
                    New.SetActive(true);
                    Invoke("NewsOFF", 1.5f);
                    news3.SetActive(true);
                }
            }
            
        }
        else
        {
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

            else if (hit.collider.tag == "LockedDrawer" && ClearLock && open)
            {
                hit.collider.GetComponent<TestScript>().DrawerMove(hit.collider.gameObject);

            }

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
        Cursor.lockState = CursorLockMode.Locked; // fasten cursur on center
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1f);
        

    }

    public void OpenLock()
    {
        ClearLock = true;
    }

    void NewsOFF()
    {
        Newspaper.SetActive(false);
    }

    void Note()
    {
        if (New==true)
        {
            if (Input.GetButtonUp("n"))
            {
                New.SetActive(false);
            }
        }
    }
}


