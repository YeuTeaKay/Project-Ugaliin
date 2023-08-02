using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfo sceneInfo;
    
    public void GoBackToWorld(string sceneName)
    {
        sceneInfo.isNextScene = isNextScene;
        SceneManager.LoadScene(sceneName);
    }
}
