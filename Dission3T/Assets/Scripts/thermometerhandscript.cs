using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thermometerhandscript : MonoBehaviour
{
    public bool R_true; //오른쪽 냉장고 온도 조절 성공 여부
    public bool L_true; //왼쪽 냉장고 온도 조절 성공 여부
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
        if(other.tag == "온도조절기" && other.transform.position.x == -0.07231)
        {
            L_true = true;
        }
        else if(other.tag == "온도조절기" && other.transform.position.x == 06869435)
        {
            R_true = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "온도조절기" && other.transform.position.x == -0.07231)
        {
            L_true = false;
        }
        else if (other.tag == "온도조절기" && other.transform.position.x == 06869435)
        {
            R_true = false;
        }
    }
}
