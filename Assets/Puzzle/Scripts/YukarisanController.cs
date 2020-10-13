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

    //アニメーション管理変数
    Animator animator;
    bool anim_jump;
    bool anim_move;

    bool isGround;

    const string goal_tag = "Goal";

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = GroundCheckObj.GetComponent<GroundCheck>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!StageController.Instance.isTimeStop)
        {
            Idle();
            Move();
        }
        SetAnimationPrameters();
        //Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        isGround = groundCheck.IsGround;
        anim_jump = !isGround;
        groundCheck.UpdateByYukarisan();
        //Debug.Log("Fixed");
    }

    void Idle()
    {
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            anim_move = false;
        }
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
            if (isGround)
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

            //向いてる方向を変更
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);

            //アニメーションをmoveに
            anim_move = true;
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
            if (isGround)
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

            //向いてる方向を変更
            transform.localScale = new Vector3(-0.4f, 0.4f, 1f);

            //アニメーションをmoveに
            anim_move = true;
        }

        //上キーが押され、かつ接地している時
        if (Input.GetKey(KeyCode.UpArrow) && isGround && rb.velocity.y < 50f)
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
                //GameManager.Instance.SaveClearStage();
                GameManager.Instance.LoadPuzzleScene();
            }
        }
    }

    void SetAnimationPrameters()
    {
        animator.SetBool("jump", anim_jump);
        animator.SetBool("move", anim_move);
    }

    public void NoticeIsGround()
    {
        isGround = true;
        //SetAnimationPrameters();
    }

}
