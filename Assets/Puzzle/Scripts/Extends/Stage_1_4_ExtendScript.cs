using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_4_ExtendScript : MonoBehaviour
{
    public GameObject[] Light;
    public float waitTime;

    BaseGimmickBehaviour[] light;

    // Start is called before the first frame update
    void Start()
    {
        light = new BaseGimmickBehaviour[Light.Length];
        for(int i = 0; i < Light.Length; i++)
        {
            light[i] = Light[i].GetComponent<BaseGimmickBehaviour>();
            if(i % 2 == 1)
            {
                light[i].TurnOn(true);
            }
        }
        StartCoroutine(BlinkLightCoroutine());
    }

    IEnumerator BlinkLightCoroutine()
    {
        while (true)
        {
            foreach(BaseGimmickBehaviour behaviour in light)
            {
                behaviour.Toggle();
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
