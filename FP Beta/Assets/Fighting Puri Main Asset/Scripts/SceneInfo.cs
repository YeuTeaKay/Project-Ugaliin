using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneInfo", menuName = "Game World/SceneInfo", order = 0)]
public class SceneInfo : ScriptableObject
{
    public bool isNextScene = true;
}
