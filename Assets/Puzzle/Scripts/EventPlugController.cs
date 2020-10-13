using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlugController : PlugController
{
    public string fileName;
    bool isPlayed;

    public override void Connect()
    {
        base.Connect();
        if (!isPlayed)
        {
            isPlayed = true;
            StartCoroutine(StageController.Instance.EventCoroutine(fileName));
        }
    }
}
