using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject canvas;

    GameObject gameSelect;
    GameObject stageSelect;

    private void Start()
    {
        gameSelect = canvas.transform.Find("GameSelect").gameObject;
        //ステージ選択画面は初期状態で隠しておく
        stageSelect = canvas.transform.Find("StageSelect").gameObject;
        stageSelect.SetActive(false);
    }

    public void OnClickNewGame()
    {
        GameManager.Instance.StageSelect(0);
        GameManager.Instance.LoadPuzzleScene();
    }

    public void OnClickLoadGame()
    {
        //ゲーム選択画面を隠してステージ選択画面に切り替える
        gameSelect.SetActive(false);
        stageSelect.SetActive(true);
    }

    public void OnClickStageNum(int number)
    {
        GameManager.Instance.StageSelect(number);
        GameManager.Instance.LoadPuzzleScene();
    }
}
