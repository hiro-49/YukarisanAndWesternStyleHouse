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
    bool isNearPlug;
    GameObject nearPlug;
    GameObject breaker;

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
        Idle();
        if (!StageController.Instance.isTimeStop)
        {
            Move();
            Action();
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
        if (StageController.Instance.isTimeStop) anim_move = false;
        if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            anim_move = false;
        }
    }

    void Move()
    {
        //右
        if (Input.GetAxis("Horizontal") > 0f)
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
        if (Input.GetAxis("Horizontal") < 0f)
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
        if (Input.GetAxis("Vertical") > 0f && isGround && rb.velocity.y < 50f)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumping_velocity;
            rb.velocity = velocity;
        }
    }

    void Action()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isNearPlug)
            {
                nearPlug.GetComponent<BaseGimmickBehaviour>().Toggle();
            }

            if(breaker != null)
            {
                breaker.GetComponent<BaseGimmickBehaviour>().Toggle();
            }
        }
    }


    //SleepModeをNeverSleepにしないと動かないと判定が止まる
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (StageController.Instance.isTimeStop) return;
    //    if(collision.gameObject.layer == LayerName.Gimmick && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("Space");
    //        collision.gameObject.GetComponent<BaseGimmickBehaviour>().Toggle();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plug")
        {
            isNearPlug = true;
            nearPlug = collision.gameObject;
        }

        if(collision.gameObject.tag == "Breaker")
        {
            breaker = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plug")
        {
            isNearPlug = false;
            nearPlug = null;
        }

        if(collision.gameObject.tag == "Breaker")
        {
            breaker = null;
        }
    }

    //ゴールのスクリプトに処理を移植
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //開いているゴールに触れるとゴール
    //    if (collision.gameObject.tag == goal_tag)
    //    {
    //        if (collision.gameObject.GetComponent<GoalController>().IsOpen)
    //        {
    //            //GameManager.Instance.SaveClearStage();
    //            GameManager.Instance.LoadPuzzleScene();
    //        }
    //    }
    //}

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
