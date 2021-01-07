using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    public static SceneCtrl instance;

    bool a;
    private int nextSceneLoad;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        StartCoroutine(WaitOneSec());
        
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
   
    IEnumerator WaitOneSec()
    {
        
        yield return new WaitForSeconds(1.5f);
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneLoad);

    }
}
