using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    float xRot, yRot, xRotMove, yRotMove;

    public float rotSpeed = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xRotMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed;
        yRotMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;

        yRot = transform.eulerAngles.y + yRotMove;

        xRot = xRot + xRotMove;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.eulerAngles = new Vector3(xRot, yRot, 0);
    }
}
