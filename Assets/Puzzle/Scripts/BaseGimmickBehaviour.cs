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
    protected bool isEnergized;
    //起動時の動作
    abstract protected void StartOperation();
    //終了時の動作
    abstract protected void EndOperation();
    //ON/OFFの切り替え
    abstract public void Toggle();

    //ONになった時
    public void TurnOn(bool isChangeState)
    {
        if (isChangeState) powerSwitchState = PowerSwitchState.ON;

        if (powerSwitchState == PowerSwitchState.ON && isEnergized)
        {
            StartOperation();
        }
    }
    //OFFになった時
    public void TurnOff(bool isChangeState)
    {
        if (isChangeState) powerSwitchState = PowerSwitchState.OFF;

        if (!(powerSwitchState == PowerSwitchState.ON && isEnergized))
        {
            EndOperation();
        }
    }

    //部屋の通電状態の管理下に置かれたギミックがStageControllerから呼ばれるメソッド
    public void Energized()
    {
        isEnergized = true;
        TurnOn(false);
    }

    public void Blocked()
    {
        isEnergized = false;
        TurnOff(false);
    }

}
