using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    //シーンに一つ
    private static StageController instance;
    public static StageController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (StageController)FindObjectOfType(typeof(StageController));
            }
            if (instance == null)
            {
                Debug.LogError(typeof(StageController) + "is nothing");
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (StageController)this;
            return true;
        }
        else if (Instance == this)
        {
            return true;
        }

        Destroy(this.gameObject);
        return false;
    }

    public float stageHeight;
    public float stageWidth;
    //public GameObject[] gimmicks;
    public GameObject conversationCanvas;

    public bool isEnergized { get; private set; }
    public bool isTimeStop = true;

    //List<BaseGimmickBehaviour> gimmickBehaviours = new List<BaseGimmickBehaviour>();    //ブレーカーの管理下に置かれるオブジェクトをインスペクターで登録する
    ConversationManager cm;

    private IEnumerator Start()
    {
        cm = conversationCanvas.GetComponent<ConversationManager>();
        //foreach(GameObject obj in gimmicks)
        //{
        //    gimmickBehaviours.Add(obj.GetComponent<BaseGimmickBehaviour>());
        //}

        yield return new WaitForSeconds(1f);
        //初期化処理がおわったら時間を動かす
        isTimeStop = false;
    }

    public void Energized()
    {
        isEnergized = true;
        Debug.Log("Energized");
        //foreach(BaseGimmickBehaviour behaviour in gimmickBehaviours)
        //{
        //    behaviour.Energized();
        //}
    }

    public void Block()
    {
        isEnergized = false;
        //foreach(BaseGimmickBehaviour behaviour in gimmickBehaviours)
        //{
        //    behaviour.Blocked();
        //}
    }


    public IEnumerator EventCoroutine(string fileName)
    {
        //時間を止める
        isTimeStop = true;
        //イベントを再生する
        Debug.Log(cm);
        List<string[]> talkData = MyCSVReader.LoadCSV(fileName);
        yield return StartCoroutine(cm.StartConversation(talkData));
        //時間を再開する
        isTimeStop = false;
    }

}
