using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //プレハブ
    //public GameObject[] DummmyStages;
    public GameObject Yukarisan;

    public List<StageConnectionElement> stageConnections;   //インスペクターでステージの連結を登録する

    public GameObject camera;
    CameraController cameraController;
    GameObject stage;
    StageController stageController;
    Dictionary<string, StageConnectionElement> stageDictionary = new Dictionary<string, StageConnectionElement>(); //ステージ連結を辞書管理
    public GameObject yukarisan;

    private void Awake()
    {
        foreach(StageConnectionElement element in stageConnections)
        {
            stageDictionary.Add(element.key, element);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //ステージ配置
        //stage = Instantiate(DummmyStages[GameManager.Instance.CurrentStageNum], Vector3.zero, Quaternion.identity);
        stage = Instantiate(stageDictionary[GameManager.Instance.nextStageKey].stage, Vector3.zero, Quaternion.identity);
        stageController = stage.GetComponent<StageController>();
        GameManager.Instance.nextStageKey = stageDictionary[GameManager.Instance.nextStageKey].nextStageKey;
        //Debug.Log("stageNum:" + GameManager.Instance.CurrentStageNum);
        //ゆかりさん配置
        Transform start = stage.transform.Find("Start");
        yukarisan = Instantiate(Yukarisan, start.position, Quaternion.identity);
        //カメラ設定
        cameraController = camera.GetComponent<CameraController>();
        cameraController.yukarisan = yukarisan;
        cameraController.stageHeight = stageController.stageHeight;
        cameraController.stageWidth = stageController.stageWidth;
        cameraController.Init();    //初期化
    }
}
    