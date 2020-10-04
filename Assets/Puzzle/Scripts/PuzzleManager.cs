﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //プレハブ
    public GameObject DummmyStage;
    public GameObject Yukarisan;

    public GameObject camera;
    CameraController cameraController;
    GameObject stage;
    StageController stageController;
    GameObject yukarisan;

    // Start is called before the first frame update
    void Start()
    {
        //ステージ配置
        stage = Instantiate(DummmyStage, new Vector3(0f, 0f, 10f), Quaternion.identity);
        stageController = stage.GetComponent<StageController>();
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
    