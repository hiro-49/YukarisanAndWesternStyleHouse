using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Data
{
    public bool[] clearedStage;

    public Data(int stageMax)
    {
        clearedStage = new bool[stageMax];
        clearedStage[0] = true;
    }
}
