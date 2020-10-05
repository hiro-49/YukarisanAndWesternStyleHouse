using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int CurrentStageNum { get; private set; }   //現在ステージ数
    int stageMax = 3;   //最大ステージ数

    //起動時にGameManagerを生成する
    [RuntimeInitializeOnLoadMethod()]
    private static void CreateGameManager()
    {
        GameObject manager = new GameObject("GameManager");
        manager.AddComponent<GameManager>();
    }

    //現在ステージを次のステージへ
    public void IncrementStageNum()
    {
        CurrentStageNum++;
        if (CurrentStageNum >= stageMax) CurrentStageNum = stageMax - 1;
    }

    //ステージ選択
    public void StageSelect(int number)
    {
        CurrentStageNum = number;
        if (CurrentStageNum >= stageMax) CurrentStageNum = 0;
    }

    public void LoadPuzzleScene()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
