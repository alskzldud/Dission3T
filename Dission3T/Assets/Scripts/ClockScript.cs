using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Rotation();
    }

    // Update is called once per frame  
    void Update()
    {
        //Rotation();
    }

    public void Rotation()
    {
        if(gameObject.transform.tag == "RightClockDoor")
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 10, 0));
        }
        if(gameObject.transform.tag == "LeftClockDoor")
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 170, 0));
        }
        if(gameObject.transform.tag == "bird")
        {
            gameObject.transform.localPosition += new Vector3(0, 0, 0.05f);
        }
    }
}
