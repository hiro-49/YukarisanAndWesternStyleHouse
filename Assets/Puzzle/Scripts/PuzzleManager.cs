using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //プレハブ
    public GameObject[] DummmyStages;
    public GameObject Yukarisan;

    public GameObject camera;
    CameraController cameraController;
    GameObject stage;
    StageController stageController;
    public GameObject yukarisan;

    // Start is called before the first frame update
    void Start()
    {
        //ステージ配置
        stage = Instantiate(DummmyStages[GameManager.Instance.CurrentStageNum], Vector3.zero, Quaternion.identity);
        stageController = stage.GetComponent<StageController>();
        Debug.Log("stageNum:" + GameManager.Instance.CurrentStageNum);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
    