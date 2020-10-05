using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//カメラのz座標は-10f!!!!!!

public class CameraController : MonoBehaviour
{
    public GameObject yukarisan;
    public float stageHeight;
    public float stageWidth;
    float attenRate = 1f; //減衰比率
    float cameraHeight = 1080f;
    float cameraWidth = 1920f;

    float up_max;
    float down_max;
    float right_max;
    float left_max;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovingWithLerpAttenuate();
        Restrict();
    }

    //線形補間減衰によるカメラ移動
    void MovingWithLerpAttenuate()
    {
        Vector3 targetPos = yukarisan.transform.position;
        Vector3 position = transform.position;
        position.z = 0f;    //一度z座標を0にして計算する
        position = Vector3.Lerp(position, targetPos, Time.deltaTime * attenRate);
        position.z = -10f;  //z座標を-10fに戻す
        transform.position = position;
        //Debug.Log("targetPos:" + targetPos);
    }

    //カメラ位置がステージをはみ出さない様に制限
    void Restrict()
    {
        Vector3 position = transform.position;
        if (position.y > up_max) position.y = up_max;
        if (position.y < down_max) position.y = down_max;
        if (position.x > right_max) position.x = right_max;
        if (position.x < left_max) position.x = left_max;
        position.z = -10f;
        transform.position = position;
    }

    //カメラ設定初期化
    public void Init()
    {
        up_max = stageHeight / 2 - cameraHeight / 2;
        down_max = cameraHeight / 2 - stageHeight / 2;
        right_max = stageWidth / 2 - cameraWidth / 2;
        left_max = cameraWidth / 2 - stageWidth / 2;
        Vector3 position = yukarisan.transform.position;
        position.z = -10f;
        transform.position = position;
    }
}
