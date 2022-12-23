using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handscript : MonoBehaviour
{
    // Start is called before the first frame update


    static bool LhandTrue;
    static bool RhandTrue;

    bool a = true;

    //public GameObject[] Light = new GameObject[2];
    public Light[] Light = new Light[2];

    public GameObject[] Clock = new GameObject[3];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RhandTrue && LhandTrue && a)
        {
            Invoke("HandTrue", 3f);
            a = false;
        }
        
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

    void HandTrue()
    {
        
        
        for(int i =0; i < 3; i++)
        {
            Clock[i].GetComponent<ClockScript>().Rotation();
        }
        for (int i = 0; i < 2; i++)
        {
            for (double j = 0; j < 37; j++)
            {
                Light[i].range += 0.1f;

            }

        }
            a = false;
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }
}
