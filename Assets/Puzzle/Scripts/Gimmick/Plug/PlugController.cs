using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugController : BaseGimmickBehaviour
{
    public GameObject targetObject; //対応するギミック
    public GameObject codePrefab;
    public float codeRange;
    public Sprite connected;
    public Sprite unconnected;

    protected bool doesYukariHave;    //ゆかりさんが持っているか
    protected bool isConnect;
    //protected bool[] isConnectCache = new bool[3];
    protected GameObject outlet;  //繋がっているコンセント
    protected string outlet_tag = "Outlet";
    protected GameObject yukarisan;   //ゆかりさん
    protected Rigidbody2D rb;
    protected BaseGimmickBehaviour targetController;
    protected Vector3 plugPivot;  //プラグの始点
    protected SpriteRenderer spriteRenderer;

    protected void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        targetController = targetObject.GetComponent<BaseGimmickBehaviour>();
        plugPivot = transform.parent.position;
        isEnergized = true; //プラグは部屋の通電状態から独立して動作する
        CreateCode();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        if (doesYukariHave) FollowYukarisan();
        if (isConnect) beConnecting();
        //UpdateCache();
    }

    //コードをつくる
    protected void CreateCode()
    {
        List<GameObject> codeJoints = new List<GameObject>();
        float length = 0f;
        while(length < codeRange)
        {
            length += 200f;
            codeJoints.Add(Instantiate(codePrefab, gameObject.transform.position, Quaternion.identity));
        }

        //pivotにjointを連結
        transform.parent.gameObject.GetComponent<JointController>().Init(codeJoints[0]);
        //joint同士の連結
        for(int i=0;i < codeJoints.Count; i++)
        {
            SpringJoint2D spring = codeJoints[i].GetComponent<SpringJoint2D>();
            //連結するオブジェクトを指定
            //最後のjointにはプラグを連結
            if(i == codeJoints.Count - 1)
            {
                codeJoints[i].GetComponent<JointController>().Init(gameObject);
            }
            else
            {
                codeJoints[i].GetComponent<JointController>().Init(codeJoints[i + 1]);
            }
            //親子関係を設定
            codeJoints[i].transform.parent = transform.parent;
        }
    }

    //ゆかりさんに掴まれている時、追従する
    //plugPivotから一定距離で自動的に落ちる (未実装
    protected void FollowYukarisan()
    {
        transform.position = yukarisan.transform.position;
        rb.velocity = Vector2.zero;
        if((transform.position - plugPivot).sqrMagnitude > codeRange * codeRange)
        {
            TurnOff(true);
        }
    }

    //コンセントに刺さっている間
    protected void beConnecting()
    {
        transform.position = outlet.transform.position;
        rb.velocity = Vector2.zero;
    }

    //protected void UpdateCache()
    //{
    //    isConnectCache[2] = isConnectCache[1];
    //    isConnectCache[1] = isConnectCache[0];
    //    isConnectCache[0] = isConnect;
    //}

    //3フレームの間状態が変わっていないか
    //protected bool IsKeepingState()
    //{
    //    if(isConnectCache[0] != isConnectCache[1])
    //    {
    //        return false;
    //    }else if(isConnectCache[0] != isConnectCache[2])
    //    {
    //        return false;
    //    }else if(isConnectCache[1] != isConnectCache[2])
    //    {
    //        return false;
    //    }
    //    return true;
    //}

    //コンセントに刺さった時
    public virtual void Connect()
    {
        isConnect = true;
        spriteRenderer.sprite = connected;
        spriteRenderer.sortingLayerName = "ConnectedPlug";
        targetController.TurnOn(true);
    }

    //コンセントから外れた時
    public void DisConnect()
    {
        targetController.TurnOff(true);
        outlet = null;
        isConnect = false;
        spriteRenderer.sprite = unconnected;
        spriteRenderer.sortingLayerName = "Plug";
    }

    

    public override void Toggle()
    {
        if (powerSwitchState == PowerSwitchState.ON)
        {
            TurnOff(true);
        }
        else
        {
            TurnOn(true);
        }
    }

    protected override void EndOperation()
    {
        doesYukariHave = false;
    }

    protected override void StartOperation()
    {
        doesYukariHave = true;
        yukarisan = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>().yukarisan;
        if (isConnect) DisConnect();
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        //ゆかりさんが持っていないプラグがコンセントの近くにあって、接続していない時、さらに状態がしばらく変わってない時
        if(collision.gameObject.tag == outlet_tag && powerSwitchState.Equals(PowerSwitchState.OFF) && outlet == null)
        {
            OutletController outletController = collision.gameObject.GetComponent<OutletController>();
            //コンセントが空いているなら接続
            if (!outletController.IsConnecting)
            {
                outlet = collision.gameObject;
                Connect();
            }
        }
    }
}
