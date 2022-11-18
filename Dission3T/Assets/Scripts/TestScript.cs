using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Vector3 target = new Vector3(1.930465f, 1.49123f, 12.71f);

    Vector3 drawertarget1 = new Vector3(5.312063f, 0.9918178f, 43.02337f);
    Vector3 drawertarget2 = new Vector3(1.930465f, 0.8712302f, 12.752f);

    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, drawertarget1, 0.05f);
    }

    public void DrawerMove()
    {
        if (!isOpen)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, drawertarget1, 0.05f);
            //new WaitForSeconds(0.3f);
            isOpen = !isOpen;
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(5.312063f, 0.9918178f, 42.08744f), 0.05f);
            //new WaitForSeconds(0.3f);
            isOpen =!isOpen;
        }
        

    }

    public IEnumerator StartMove()
    {
        
        if (gameObject.transform.localPosition.z > 0.9f && gameObject.transform.localPosition.z < 1.13286)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, drawertarget1, 0.05f);
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(5.312063f, 0.9918178f, 42.08744f), 0.05f);
        }
        yield return new WaitForSeconds(0.001f);

    }
}
