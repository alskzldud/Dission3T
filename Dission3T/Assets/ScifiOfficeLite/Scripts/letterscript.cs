using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class letterscript : MonoBehaviour
{
    public MeshRenderer letterondesk;
    Material m;

    public GameObject text;

    public GameObject letterImage;

    Image letter;

    public Button btn;

    Vector3 target = new Vector3(4.342f, 1.01f, 32f);
    Vector3 origin;

    bool letterClick = false;


    // Start is called before the first frame update
    void Start()
    {
        m = letterondesk.GetComponent<Material>();

        origin = text.transform.position;

        letter = letterImage.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("origin = " + origin);
        Debug.Log("text position = " + text.transform.position);

        letterUp();
    }

    private void OnMouseDown()
    {
        letterClick = true;
    }

    private void OnMouseOver()
    {
        //Debug.Log("blinkAnim start");

        StartCoroutine(blinkAnim());

        StartCoroutine(textUp());
    }

    private void OnMouseExit()
    {
        Debug.Log("exit ¿€µø ¡ﬂ");
        StartCoroutine(textDown());
    }


    IEnumerator blinkAnim()
    {

        bool up = false;
        Color c = letterondesk.material.color;
        if (letterondesk.material.color.a == 0f)
        {
            up = true;
        }
        if (letterondesk.material.color.a < 0.6f && up)
        {
            for (int i = 0; i < 7; i++)
            {
                //Debug.Log("c.a +");
                float f = i / 10.0f;
                c.a = f;
                letterondesk.material.color = c;
                //Debug.Log(letterondesk.material.color);

                yield return new WaitForSeconds(0.1f);


            }

        }
        else if (letterondesk.material.color.a == 0.6f)
        {
            up = false;
            for (int i = 6; i >= 0; i--)
            {
                //Debug.Log("c.a -");
                float f = i / 10.0f;
                c.a = f;
                letterondesk.material.color = c;
                //Debug.Log(letterondesk.material.color);
                yield return new WaitForSeconds(0.1f);
            }
        }

    }

    IEnumerator textUp()
    {

        text.transform.position = Vector3.Lerp(text.transform.position, target, 0.05f);
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator textDown()
    {
        //text.transform.position = Vector3.Lerp(text.transform.position, origin, 0.05f);
        text.transform.position = origin;
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator LetterShow()
    {

        Color c = letter.color;

        Image img = btn.GetComponent<Image>();

        Text txt = btn.transform.GetChild(0).GetComponent<Text>();

        Color t = txt.color;
        Color b = img.color;
        if (letter.color.a < 1)
        {
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10f;
                c.a = f;
                letter.color = c;
                yield return new WaitForSeconds(0.1f);

            }

            for (int i = 0; i < 11; i++)
            {
                float f = i / 10f;
                b.a = f;
                t.a = f;
                img.color = b;
                txt.color = t;
                yield return new WaitForSeconds(0.1f);

            }

        }
    }

    void letterUp()
    {
        if (letterClick)
        {
            StartCoroutine(LetterShow());
            letterClick = false;
            ScifiOffice.DemoFirstPersonController demoFirstPersonController = Camera.main.GetComponent<ScifiOffice.DemoFirstPersonController>();

            demoFirstPersonController.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            text.SetActive(false); 
        }
    }
}
