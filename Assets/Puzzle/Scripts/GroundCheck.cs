using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void FixedUpdate()
    {
        IsGround = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerName.Floor || collision.gameObject.layer == LayerName.Scaffold) IsGround = true;
    }
}
