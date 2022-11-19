using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public Transform player;
    public GameObject RockUI;
    public GameObject PObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "RockUI")
        {
            transform.LookAt(player);
        }

        
    }

    public void RockOpen()
    {
        
        RockUI.transform.position = player.position + Camera.main.transform.forward * 0.9f;

        RayCenter rCenter = PObject.GetComponent<RayCenter>();
        PlayerMove pMove = PObject.GetComponent<PlayerMove>();
        PlayerRotate pRot = PObject.GetComponent<PlayerRotate>();
        CamRotate cRot = Camera.main.GetComponent<CamRotate>();
        rCenter.enabled = false;
        pMove.enabled = false;
        pRot.enabled = false;
        cRot.enabled = false;
        Debug.Log(rCenter.enabled);
        Debug.Log(pMove.enabled);
        Debug.Log(pRot.enabled);
    }

    
}
