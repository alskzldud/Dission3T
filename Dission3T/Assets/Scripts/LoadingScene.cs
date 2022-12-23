using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{

    static string nextScene;

    public Scrollbar bar;
    Scrollbar s;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    // Start is called before the first frame update
    void Start()
    {

        s = bar.GetComponent<Scrollbar>();
        StartCoroutine(LoadSceneProgress());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSceneProgress()
    {
        float timer = 1f;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        yield return new WaitForSeconds(1f);
        s.size = Mathf.Lerp(0f, 1f, timer);

        if(s.size == 1f)
        op.allowSceneActivation = true;
        
        
        /*while (!op.isDone)
        {
            yield return null;
            
            if (op.progress < 0.9f)
            {
                timer += Time.unscaledDeltaTime;
                s.size = Mathf.Lerp(0f, 0.9f, timer);

                
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                s.size = Mathf.Lerp(0.9f, 1f, timer);
                if (s.size >= 1f)
                {
                    yield return new WaitForSeconds(10f);
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }*/
    }
}
