using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handscript : MonoBehaviour
{
    // Start is called before the first frame update


    public bool RhandTrue;
    public bool LhandTrue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("콜라이더와 접촉함");
        if(other.tag == "Rhandcollider")
        {
            RhandTrue = true;
            Debug.Log(RhandTrue);
        }
        else if(other.tag == "Lhandcollider")
        {
            LhandTrue = true;
            Debug.Log(LhandTrue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rhandcollider")
        {
            RhandTrue = false;
            Debug.Log(RhandTrue);
        }
        else if (other.tag == "Lhandcollider")
        {
            LhandTrue = false;
            Debug.Log(LhandTrue);
        }
    }
}
