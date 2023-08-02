using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPTest : MonoBehaviour
{
    public string playerName;
    public TMP_Text canvasText;


    void Start()
    {
        canvasText.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
