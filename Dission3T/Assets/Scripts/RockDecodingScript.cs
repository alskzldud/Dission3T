using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class RockDecodingScript : MonoBehaviour
{
    static bool[] Numbers = new bool[10];
    GameObject player;

    public GameObject LockUI;

    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
         player = GameObject.Find("Player");
         if (Numbers[0] == true && Numbers[1] == true && Numbers[2] == true && Numbers[3] == false && Numbers[4] == true && Numbers[5] == false && Numbers[6] == false && Numbers[7] == false && Numbers[8] == false && Numbers[9] == false)
         {


            PlayerMove pMove = player.GetComponent<PlayerMove>();
            PlayerRotate pRot = player.GetComponent<PlayerRotate>();
            CamRotate cRot = Camera.main.GetComponent<CamRotate>();
            RayCenter r = player.GetComponent<RayCenter>();
            r.OpenLock();

            pMove.enabled = true;
            pRot.enabled = true;
            cRot.enabled = true;
            r.enabled = true;

            LockUI.SetActive(false);
            
         }
        
         if(Input.GetButton("Cancel"))
        {
            this.transform.localPosition = startPosition;
        }

    }
        void OnMouseDown()
        {



            Debug.Log("�ϴ� �۵��� �ǰ� ����...");
            if (this.gameObject.name == "1") // �ڹ����� 1�� ������ ��
            {
                Debug.Log("1�� Ŭ����");
                this.gameObject.transform.position += transform.forward * -0.017f; // ������ ���
                Numbers[1] = true;
                //Debug.Log(Numbers[1]);


            }
            if (this.gameObject.name == "2") // �ڹ����� 2�� ������ ��
            {
                Debug.Log("2�� Ŭ����");
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[2] = true;
                //Debug.Log(Numbers[2]);


            }
            else if (this.gameObject.name == "3") // �ڹ����� 3�� ������ ��
            {
                Debug.Log("3�� Ŭ����");
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[3] = true;


            }
            else if (this.gameObject.name == "4") // �ڹ����� 4�� ������ ��
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[4] = true;
                //Debug.Log(Numbers[4]);

            }
            else if (this.gameObject.name == "5")
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[5] = true;

            }
            else if (this.gameObject.name == "6")
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[6] = true;


            }
            else if (this.gameObject.name == "7")
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[7] = true;


            }
            else if (this.gameObject.name == "8")
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[8] = true;

            }
            else if (this.gameObject.name == "9")
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[9] = true;

            }
            else if (this.gameObject.name == "0")
            {
                this.gameObject.transform.position += transform.forward * -0.017f;
                Numbers[0] = true;
                //Debug.Log(Numbers[0]);

            }
        }

    public void format()
    {
        
        startPosition = this.transform.localPosition;
        
    }
    public void numFormat()
    {
        for (int i = 0; i < 10; i++)
        {
            Numbers[i] = false;
        }
    }
}

