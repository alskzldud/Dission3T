using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public Transform player;
    public GameObject RockUI;
    public GameObject PObject;



    public bool UIing;
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

        if (Input.GetButton("Cancel") && UIing)
        {
            RayCenter rCenter = PObject.GetComponent<RayCenter>();
            PlayerMove pMove = PObject.GetComponent<PlayerMove>();
            PlayerRotate pRot = PObject.GetComponent<PlayerRotate>();
            CamRotate cRot = Camera.main.GetComponent<CamRotate>();
            RockUI.transform.position = new Vector3(50, 50, 50);
            rCenter.enabled = true;
            pMove.enabled = true;
            pRot.enabled = true;
            cRot.enabled = true;
            UIing = false;
            
        }

    }

    public void RockOpen()
    {

        
        UIing = true;
        RockUI.transform.position = player.position + Camera.main.transform.forward * 0.9f;

        RayCenter rCenter = PObject.GetComponent<RayCenter>();
        PlayerMove pMove = PObject.GetComponent<PlayerMove>();
        
        CamRotate cRot = Camera.main.GetComponent<CamRotate>();
        rCenter.enabled = false;
        pMove.enabled = false;
        
        cRot.enabled = false;
        
        Transform mesh = RockUI.transform.GetChild(0);
        Transform four = mesh.transform.GetChild(2);
        Transform nine = mesh.transform.GetChild(3);
        Transform three = mesh.transform.GetChild(4);
        Transform eight = mesh.transform.GetChild(5);
        Transform two = mesh.transform.GetChild(6);
        Transform seven = mesh.transform.GetChild(7);
        Transform one = mesh.transform.GetChild(8);
        Transform six = mesh.transform.GetChild(9);
        Transform zero = mesh.transform.GetChild(10);
        Transform five = mesh.transform.GetChild(11);
        

        
        RockDecodingScript zeroScript = zero.GetComponent<RockDecodingScript>();
        RockDecodingScript oneScript = one.GetComponent<RockDecodingScript>();
        RockDecodingScript twoScript = two.GetComponent<RockDecodingScript>();
        RockDecodingScript threeScript = three.GetComponent<RockDecodingScript>();
        RockDecodingScript fourScript = four.GetComponent<RockDecodingScript>();
        RockDecodingScript fiveScript = five.GetComponent<RockDecodingScript>();
        RockDecodingScript sixScript = six.GetComponent<RockDecodingScript>();
        RockDecodingScript sevenScript = seven.GetComponent<RockDecodingScript>();
        RockDecodingScript eightScript = eight.GetComponent<RockDecodingScript>();
        RockDecodingScript nineScript = nine.GetComponent<RockDecodingScript>();


        zeroScript.numFormat();
        zeroScript.format();
        oneScript.format();
        twoScript.format();
        threeScript.format();
        fourScript.format();
        fiveScript.format();
        sixScript.format();
        sevenScript.format();
        eightScript.format();
        nineScript.format();

        
        
    }

    
}
