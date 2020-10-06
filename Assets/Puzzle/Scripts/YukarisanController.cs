using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukarisanController : MonoBehaviour
{
    public GameObject GroundCheckObj;
    public float jumping_velocity;
    public float moving_power;
    public float velocity_max;

    Rigidbody2D rb;
    GroundCheck groundCheck;

    const string goal_tag = "Goal";

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = GroundCheckObj.GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //逆入力で減速
            if(rb.velocity.x < 0f)
            {
                Vector2 velocity = rb.velocity;
                velocity.x /= 2f;
                rb.velocity = velocity;
            }

            //速度制限をつけた移動
            if (groundCheck.IsGround)
            {
                if(rb.velocity.magnitude < velocity_max)
                {
                    rb.AddForce(new Vector2(moving_power, 0f));
                }
            }
            else
            {
                if(rb.velocity.x < velocity_max)
                {
                    rb.AddForce(new Vector2(moving_power, 0f));
                }
            }
        }
        //左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //逆入力で減速
            if (rb.velocity.x > 0f)
            {
                Vector2 velocity = rb.velocity;
                velocity.x /= 2f;
                rb.velocity = velocity;
            }

            //速度制限をつけた移動
            if (groundCheck.IsGround)
            {
                if (rb.velocity.magnitude < velocity_max)
                {
                    rb.AddForce(new Vector2(-moving_power, 0f));
                }
            }
            else
            {
                if(rb.velocity.x > -velocity_max)
                {
                    rb.AddForce(new Vector2(-moving_power, 0f));
                }
            }
        }
        //上キーが押され、かつ接地している時
        if (Input.GetKey(KeyCode.UpArrow) && groundCheck.IsGround && rb.velocity.y < 50f)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumping_velocity;
            rb.velocity = velocity;
        }
    }


    //SleepModeをNeverSleepにしないと動かないと判定が止まる
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerName.Gimmick && Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.GetComponent<BaseGimmickBehaviour>().Toggle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //開いているゴールに触れるとゴール
        if (collision.gameObject.tag == goal_tag)
        {
            if (collision.gameObject.GetComponent<GoalController>().IsOpen)
            {
                GameManager.Instance.SaveClearStage();
                GameManager.Instance.IncrementStageNum();
                GameManager.Instance.LoadPuzzleScene();
            }
        }
    }

}
