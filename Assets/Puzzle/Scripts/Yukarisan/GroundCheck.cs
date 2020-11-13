using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGround { get; private set; }
    //bool[] cacheIsGround = new bool[3];
    YukarisanController yukarisan;

    private void Start()
    {
        yukarisan = transform.parent.gameObject.GetComponent<YukarisanController>();
    }

    public void UpdateByYukarisan()
    {
        IsGround = false;
        //cacheIsGround[0] = cacheIsGround[1];
        //cacheIsGround[1] = cacheIsGround[2];
        //cacheIsGround[2] = false;
    }

    //public bool IsGround()
    //{
    //    foreach (bool isGround in cacheIsGround)
    //    {
    //        if (isGround) return true;
    //    }
    //    //Debug.Log("Return true");
    //    return false;
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == LayerName.Floor || layer == LayerName.Scaffold || layer == LayerName.Obstacle || layer == LayerName.Box) IsGround = true;
        yukarisan.NoticeIsGround();
        //Debug.Log("OnTriggerStay");
    }
}
