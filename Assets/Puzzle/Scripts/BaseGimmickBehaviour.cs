using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerSwitchState
{
    ON,
    OFF
}

abstract public class BaseGimmickBehaviour : MonoBehaviour
{
    protected PowerSwitchState powerSwitchState = PowerSwitchState.OFF;
    //ONになった時
    abstract public void TurnOn();
    //OFFになった時
    abstract public void TurnOff();
    //ON/OFFの切り替え
    abstract public void Toggle();
}
