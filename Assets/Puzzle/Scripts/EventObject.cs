using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    public string fileName; //シナリオファイル名

    bool isPlayed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPlayed) return;
        if(collision.gameObject.tag == "Player" && !StageController.Instance.isTimeStop)
        {
            isPlayed = true;
            StartCoroutine(StageController.Instance.EventCoroutine(fileName));
        }
    }
}
