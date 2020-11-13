using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ステージの名前は1~,
//対応する番号は0~
public class GameManager : SingletonBehaviour<GameManager>
{
    //public int CurrentStageNum { get; private set; }   //現在ステージ数
    //public string nextStageKey  = "1-1";
    public GameObject loadingStage;

    public int StageMax { get; } = 3;

    //クリア済みフラグ
    public Data data;
    //BGMManager
    //public BGMManager bgm;

    Stages stageData;
    Dictionary<string, GameObject> stages;

    //起動時にGameManagerを生成する
    [RuntimeInitializeOnLoadMethod()]
    private static void CreateGameManager()
    {
        GameObject manager = new GameObject("GameManager");
        manager.AddComponent<GameManager>();
    }

    private void Awake()
    {
        base.Awake();
        //data = MyDataIO.LoadData();
        GameObject bgm = new GameObject("BGMManager");
        bgm.AddComponent<BGMManager>();
        BGMManager.Instance.Init();
        stageData = Resources.Load<Stages>("StagesData/Stages");
        stages = stageData.ToDictionary();
        loadingStage = stages["1-1"];
    }

    //クリアステージを保存
    //public void SaveClearStage()
    //{
    //    data.clearedStage[CurrentStageNum] = true;
    //    MyDataIO.SaveData();
    //}

    //現在ステージを次のステージへ
    //public void IncrementStageNum()
    //{
    //    CurrentStageNum++;
    //    if (CurrentStageNum >= StageMax) CurrentStageNum = StageMax - 1;
    //}

    //ステージ選択
    //public void StageSelect(string next)
    //{
    //    //CurrentStageNum = number;
    //    //if (CurrentStageNum >= StageMax) CurrentStageNum = 0;
    //    nextStageKey = next;
    //}

    public void LoadPuzzleScene(string stageKey)
    {
        loadingStage = stages[stageKey];
        FadeManager.Instance.LoadScene("Puzzle", 3f);
    }

    public void RestartStage()
    {
        FadeManager.Instance.LoadScene("Puzzle", 1f);
    }

    //セーブデータがない時に作る
    //public void CreateNewData()
    //{
    //    data = new Data(StageMax);
    //}
}
