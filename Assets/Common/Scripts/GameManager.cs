using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ステージの名前は1~,
//対応する番号は0~
public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentStageNum { get; private set; }   //現在ステージ数
    public string nextStageKey  = "1-1";
    public int StageMax { get; } = 3;

    //クリア済みフラグ
    public Data data;

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
        data = MyDataIO.LoadData();
    }

    //クリアステージを保存
    public void SaveClearStage()
    {
        data.clearedStage[CurrentStageNum] = true;
        MyDataIO.SaveData();
    }

    //現在ステージを次のステージへ
    //public void IncrementStageNum()
    //{
    //    CurrentStageNum++;
    //    if (CurrentStageNum >= StageMax) CurrentStageNum = StageMax - 1;
    //}

    //ステージ選択
    public void StageSelect(string next)
    {
        //CurrentStageNum = number;
        //if (CurrentStageNum >= StageMax) CurrentStageNum = 0;
        nextStageKey = next;
    }

    public void LoadPuzzleScene()
    {
        FadeManager.Instance.LoadScene("Puzzle", 2f);
    }

    //セーブデータがない時に作る
    public void CreateNewData()
    {
        data = new Data(StageMax);
    }
}
