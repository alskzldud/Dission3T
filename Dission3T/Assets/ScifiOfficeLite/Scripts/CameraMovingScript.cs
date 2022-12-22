using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingScript : MonoBehaviour
{
    Vector3 dir;
    bool cinemaStart = false;
    public float rotateSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 dir = new Vector3(-1, 1, 0);
        cinemaStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        float yAngle = rotateSpeed * Time.deltaTime * 2f;
        float xAngle = rotateSpeed * Time.deltaTime * 0.1f;
        if (cinemaStart)
        {
            Camera.main.transform.Rotate(xAngle, yAngle, 0);
            /* for(int i = 0; i < 20; i++)
            {
                rotateSpeed--;
            }*/
            Invoke("off", 2.5f);
        }
        if(rotateSpeed == 0)
        {
            off();
        }
    }
    
    void cinematic()
    {
        for (int i = 0; i < 10; i++)
        {
           
            Camera.main.transform.eulerAngles += new Vector3(-1, 1, 0) * 5;
            
        }

        cinemaStart = false;
    }

    void off()
    {
        cinemaStart = false;
    }
}

