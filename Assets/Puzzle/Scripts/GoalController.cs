using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : BaseGimmickBehaviour
{
    public bool IsOpen { get; private set; }

    public override void Toggle()
    {
    }

    protected override void EndOperation()
    {
        IsOpen = false;
    }

    protected override void StartOperation()
    {
        IsOpen = true;
    }
}
