using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDecodingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnMouseDown()
        {
            Debug.Log("일단 작동은 되고 있음...");
            if(gameObject.name == "1")
            {
                Debug.Log("1을 클릭함");
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if(gameObject.name == "2")
            {
                Debug.Log("2를 클릭함");
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "3")
            {
                Debug.Log("3을 클릭함");
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);

            }
            else if (gameObject.name == "4")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "5")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "6")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "7")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "8")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "9")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }
            else if (gameObject.name == "0")
            {
                //this.gameObject.transform.position += new Vector3(-0.017f, 0, 0);
            }

        }

    }
}
