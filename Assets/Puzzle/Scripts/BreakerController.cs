using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerController : BaseGimmickBehaviour
{
    public Sprite breaker_up;
    public Sprite breaker_down;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Toggle()
    {
        if (powerSwitchState == PowerSwitchState.ON)
        {
            powerSwitchState = PowerSwitchState.OFF;
            TurnOff();
        }
        else
        {
            powerSwitchState = PowerSwitchState.ON;
            TurnOn();
        }
    }

    public override void TurnOff()
    {
        spriteRenderer.sprite = breaker_down;
        transform.parent.gameObject.GetComponent<StageController>().Energized();
    }

    public override void TurnOn()
    {
        spriteRenderer.sprite = breaker_up;
        transform.parent.gameObject.GetComponent<StageController>().Block();
    }
}
