using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject noteOpen;

    void Update()
    {
        //노트가 열려있을 때
        if (noteOpen.activeSelf == true)
        {
            //n을 누르면
            if (Input.GetKeyDown("n"))
            {
                //노트 닫기
                noteOpen.SetActive(false);
            }
        }
        //노트가 닫혀있을 때
        else
        {
            //n을 누르면
            if (Input.GetKeyDown("n"))
            {
                //노트 열기
                noteOpen.SetActive(true);
            }
        }

        
    }
}
