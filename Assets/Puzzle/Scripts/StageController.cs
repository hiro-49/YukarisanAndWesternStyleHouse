using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public float stageHeight;
    public float stageWidth;

    public bool isEnergized { get; private set; }

    public void Energized()
    {
        isEnergized = true;
    }

    public void Block()
    {
        isEnergized = false;
    }

}
