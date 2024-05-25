using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameDebugging : MonoBehaviour
{
    public enum limits
    {
        nolimit = 0,
        limit30 = 30,
        limit60 = 60,
        limit120 = 120,
        limit240 = 240
    }
    public limits limit;

    private void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }
}