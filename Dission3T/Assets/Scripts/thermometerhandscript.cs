using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thermometerhandscript : MonoBehaviour
{
    public bool R_true; //������ ����� �µ� ���� ���� ����
    public bool L_true; //���� ����� �µ� ���� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "�µ�������" && other.transform.position.x == -0.07231)
        {
            L_true = true;
        }
        else if(other.tag == "�µ�������" && other.transform.position.x == 06869435)
        {
            R_true = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "�µ���" && other.transform.position.x == -0.07231)
        {
            L_true = false;
        }
        else if (other.tag == "�µ���" && other.transform.position.x == 06869435)
        {
            R_true = false;
        }
    }
}
