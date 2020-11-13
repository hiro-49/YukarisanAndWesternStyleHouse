using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : BaseGimmickBehaviour
{
    public Sprite switchUp;
    public Sprite switchDown;
    public GameObject target;

    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    protected override void StartOperation()
    {
        spriteRenderer.sprite = switchUp;
        target.GetComponent<BaseGimmickBehaviour>().TurnOn(true);
    }

    protected override void EndOperation()
    {
        spriteRenderer.sprite = switchDown;
        target.GetComponent<BaseGimmickBehaviour>().TurnOff(true);
    }
}
