using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : BaseGimmickBehaviour
{
    public GameObject maskObj;

    //SpriteMask mask;

    private void Start()
    {
        //mask = maskObj.GetComponent<SpriteMask>();
        //mask.enabled = false;
        maskObj.SetActive(false);
    }

    public override void Toggle()
    {

    }

    protected override void StartOperation()
    {
        maskObj.SetActive(true);
        Debug.Log("TurnOnLight");
        //mask.enabled = true;
    }

    protected override void EndOperation()
    {
        maskObj.SetActive(false);
        //mask.enabled = false;
    }
}
