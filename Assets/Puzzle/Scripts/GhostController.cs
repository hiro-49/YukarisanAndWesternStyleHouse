using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject Obstacle;

    SpriteRenderer spriteRenderer;
    BoxCollider2D obstacleCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obstacleCollider = Obstacle.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            obstacleCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            obstacleCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
    }

}
