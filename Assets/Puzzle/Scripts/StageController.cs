using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public float stageHeight;
    public float stageWidth;
    public GameObject[] gimmicks;

    public bool isEnergized { get; private set; }

    List<BaseGimmickBehaviour> gimmickBehaviours = new List<BaseGimmickBehaviour>();

    private void Start()
    {
        foreach(GameObject obj in gimmicks)
        {
            gimmickBehaviours.Add(obj.GetComponent<BaseGimmickBehaviour>());
        }
    }

    public void Energized()
    {
        isEnergized = true;
        Debug.Log("Energized");
        foreach(BaseGimmickBehaviour behaviour in gimmickBehaviours)
        {
            behaviour.Energized();
        }
    }

    public void Block()
    {
        isEnergized = false;
        foreach(BaseGimmickBehaviour behaviour in gimmickBehaviours)
        {
            behaviour.Blocked();
        }
    }

}
