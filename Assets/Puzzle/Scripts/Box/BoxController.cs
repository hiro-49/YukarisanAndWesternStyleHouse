using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Right,
    Left,
    None
}

public class BoxController : MonoBehaviour { 
    Coroutine moving;
    Direction Touching = Direction.None;

    const float movingTime = 0.2f;
    const float movingSpeed = 100f;

    private void Start()
    {
    }

    public void Push(Direction direction)
    {
        if (moving != null) return;
        if (Touching == direction) return;
        moving = StartCoroutine(MoveCoroutine(direction));
    }

    IEnumerator MoveCoroutine(Direction direction)
    {
        float directionValue = direction == Direction.Right ? 1f : -1f;
        float time = 0f;
        while(time < movingTime)
        {
            Vector3 position = transform.position;
            position.x += movingSpeed * Time.deltaTime * directionValue;
            transform.position = position;
            time += Time.deltaTime;
            yield return null;
        }
        moving = null;
    }

    public void CollisionWithObstacle(Direction direction)
    {
        Touching = direction;
        if (moving != null)
        {
            StopCoroutine(moving);
            moving = null;
        }

    }

    public void LeaveFromObstacle()
    {
        Touching = Direction.None;
    }
}
