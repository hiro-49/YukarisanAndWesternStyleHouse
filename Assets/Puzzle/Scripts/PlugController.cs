using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugController : BaseGimmickBehaviour
{
    public GameObject targetObject; //対応するギミック
    public float codeRange;

    bool doesYukariHave;    //ゆかりさんが持っているか
    bool isConnect;
    GameObject outlet;  //繋がっているコンセント
    string outlet_tag = "Outlet";
    GameObject yukarisan;   //ゆかりさん
    Rigidbody2D rb;
    BaseGimmickBehaviour targetController;
    Vector3 plugPivot;  //プラグの始点

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        targetController = targetObject.GetComponent<BaseGimmickBehaviour>();
        plugPivot = transform.parent.position;
    }

    private void Update()
    {
        if (doesYukariHave) FollowYukarisan();
        if (isConnect) beConnecting();
    }

    //ゆかりさんに掴まれている時、追従する
    //plugPivotから一定距離で自動的に落ちる (未実装
    void FollowYukarisan()
    {
        transform.position = yukarisan.transform.position;
        rb.velocity = Vector2.zero;
        if((transform.position - plugPivot).sqrMagnitude > codeRange * codeRange)
        {
            TurnOff();
        }
    }

    //コンセントに刺さっている間
    void beConnecting()
    {
        transform.position = outlet.transform.position;
        rb.velocity = Vector2.zero;
    }

    //コンセントに刺さった時
    public void Connect()
    {
        isConnect = true;
        targetController.TurnOn();
    }

    //コンセントから外れた時
    public void DisConnect()
    {
        targetController.TurnOff();
        outlet = null;
        isConnect = false;
    }

    public override void Toggle()
    {
        if (powerSwitchState == PowerSwitchState.ON)
        {
            powerSwitchState = PowerSwitchState.OFF;
            TurnOff();
        }
        else
        {
            powerSwitchState = PowerSwitchState.ON;
            TurnOn();
        }
    }

    public override void TurnOff()
    {
        doesYukariHave = false;
    }

    public override void TurnOn()
    {
        doesYukariHave = true;
        yukarisan = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>().yukarisan;
        if (isConnect) DisConnect();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //ゆかりさんが持っていないプラグがコンセントの近くにあって、接続していない時
        if(collision.gameObject.tag == outlet_tag && powerSwitchState.Equals(PowerSwitchState.OFF) && outlet == null)
        {
            OutletController outletController = collision.gameObject.GetComponent<OutletController>();
            //コンセントが空いているなら
            if (!outletController.IsConnecting)
            {
                outlet = collision.gameObject;
                Connect();
            }
        }
    }
}
