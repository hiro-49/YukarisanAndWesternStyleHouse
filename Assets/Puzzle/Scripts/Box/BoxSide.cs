using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSide : MonoBehaviour
{
    public Direction direction;
    BoxController box;
    
    // Start is called before the first frame update
    void Start()
    {
        box = transform.parent.gameObject.GetComponent<BoxController>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //障害物とぶつかった時
        if(collision.tag == "Obstacle")
        {
            Debug.Log("Collisiton");
            box.CollisionWithObstacle(direction);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            Direction d = Direction.None;
            if (direction == Direction.Left) d = Direction.Right;
            if (direction == Direction.Right) d = Direction.Left;
            box.Push(d);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //障害物から離れた
        if(collision.tag == "Obstacle")
        {
            box.LeaveFromObstacle();
        }
    }
}
