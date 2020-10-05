using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : BaseGimmickBehaviour
{
    public bool IsOpen { get; private set; }

    public override void Toggle()
    {
    }

    public override void TurnOff()
    {
        IsOpen = false;
    }

    public override void TurnOn()
    {
        IsOpen = true;
    }
}
