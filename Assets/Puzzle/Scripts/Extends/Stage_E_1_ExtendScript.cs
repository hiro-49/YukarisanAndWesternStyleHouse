using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_E_1_ExtendScript : MonoBehaviour
{
    public GameObject light;
    public string endingFileName;

    private IEnumerator Start()
    {
        light.GetComponent<BaseGimmickBehaviour>().TurnOn(true);
        yield return StartCoroutine(StageController.Instance.EventCoroutine(endingFileName));
        FadeManager.Instance.LoadScene("Title", 5f);
    }
}
