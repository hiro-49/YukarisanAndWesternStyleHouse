using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //プレハブ
    //public GameObject[] DummmyStages;
    public GameObject Yukarisan;


    public GameObject camera;
    CameraController cameraController;
    GameObject stage;
    StageController stageController;
    public GameObject yukarisan;

    private void Awake()
    {
        //foreach(StageConnectionElement element in stageConnections)
        //{
        //    stageDictionary.Add(element.key, element);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        //ステージ配置
        //stage = Instantiate(DummmyStages[GameManager.Instance.CurrentStageNum], Vector3.zero, Quaternion.identity);
        stage = Instantiate(GameManager.Instance.loadingStage, Vector3.zero, Quaternion.identity);
        stageController = stage.GetComponent<StageController>();
        //GameManager.Instance.nextStageKey = stageDictionary[GameManager.Instance.nextStageKey].nextStageKey;
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

    private void Update()
    {
        CheckKey();
    }

    private void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        if (stageController.isTimeStop) return;
        GameManager.Instance.RestartStage();
    }
}
    