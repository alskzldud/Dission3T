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
    //�Ź� ���� ȹ�� UI
    public GameObject Newspaper;
    public GameObject New;
    //��Ʈ�� ǥ��
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
                if (hit.collider.tag == "����")
                {
                    Debug.Log("������ ���̿� �ε���!");
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
                    Debug.Log("�Ź����� ȹ��");
                    Destroy(Newspaper1);
                    Newspaper.SetActive(true);
                    New.SetActive(true);
                    Invoke("NewsOFF", 1.5f);
                    news1.SetActive(true);

                }
                else if (hit.collider.tag == "Newspaper2")
                {
                    Debug.Log("�Ź����� ȹ��");
                    Destroy(Newspaper2);
                    Newspaper.SetActive(true);
                    New.SetActive(true);
                    Invoke("NewsOFF", 1.5f);
                    news2.SetActive(true);
                }
                else if (hit.collider.tag == "Newspaper3")
                {
                    Debug.Log("�Ź����� ȹ��");
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
            if (hit.collider.tag == "����" && open)
            {

                Debug.Log("������ Ŭ����");

                hit.collider.GetComponent<TestScript>().DrawerMove();




            }


            else if (hit.collider.tag == "����" && !open && !ClickDelay)
            {

                hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, drawertarget2, 0.05f);

            }

            else if (hit.collider.tag == "LockedDrawer" && ClearLock && open)
            {
                hit.collider.GetComponent<TestScript>().DrawerMove(hit.collider.gameObject);

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


