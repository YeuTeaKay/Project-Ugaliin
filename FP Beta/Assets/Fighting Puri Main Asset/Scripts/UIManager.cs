using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    
    private Image Background;
    [SerializeField]
    private Sprite[] Sprites;


    private int x;

    void Start()
    {
        x = Random.Range(0, 2);

        Background.sprite = Sprites[x];

    }
    
}
