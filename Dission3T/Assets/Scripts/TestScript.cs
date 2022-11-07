using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    Vector3 target = new Vector3(1.930465f, 1.49123f, 12.71f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velo = Vector3.zero;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);
    }
}
