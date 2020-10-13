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
        isEnergized = true; //ブレーカーは部屋の通電状態から独立して動作する
    }

    public override void Toggle()
    {
        if (powerSwitchState == PowerSwitchState.ON)
        {
            TurnOff(true);
        }
        else
        {
            TurnOn(true);
        }
    }

    protected override void EndOperation()
    {
        spriteRenderer.sprite = breaker_down;
        StageController.Instance.Block();
    }

    protected override void StartOperation()
    {
        spriteRenderer.sprite = breaker_up;
        StageController.Instance.Energized();
    }
}
