using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{

    [Header("Main Quest")]
    [SerializeField] private GameObject FirstTask;
    [SerializeField] private GameObject SecondTask;
    [SerializeField] private GameObject SecondSubTask;
    [SerializeField] private GameObject ThirdTask;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameData data = DataPersistenceManager.instance.GetGameData();
        if (data != null && data.playerProgress == 0)
        {
            FirstTask.SetActive(true);
            SecondTask.SetActive(false);
            SecondSubTask.SetActive(false);
            ThirdTask.SetActive(false);
        }
        
        if (data != null && data.playerProgress >= 1)
        {
            FirstTask.SetActive(false);
            SecondTask.SetActive(true);
            SecondSubTask.SetActive(true);
            ThirdTask.SetActive(false);
        }

        if (data != null && data.playerProgress == 5)
        {
            FirstTask.SetActive(false);
            SecondTask.SetActive(false);
            SecondSubTask.SetActive(false);
            ThirdTask.SetActive(true);
        }
    }


}
