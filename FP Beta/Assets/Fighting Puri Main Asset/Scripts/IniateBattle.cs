using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniateBattle : MonoBehaviour
{
    
    public string sceneName;
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfo sceneInfo;


    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }

    }

}
