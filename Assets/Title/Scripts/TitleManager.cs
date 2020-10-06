using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //未クリアステージは選択不可に
        for(int i = 0; i < GameManager.Instance.StageMax; i++)
        {
            string buttonName = "StageNum_" + i.ToString();
            stageSelect.transform.Find(buttonName).gameObject.SetActive(GameManager.Instance.data.clearedStage[i]);
        }
        stageSelect.SetActive(false);
        //NewGameを選択状態にしておく
        gameSelect.transform.Find("NewGame").gameObject.GetComponent<Button>().Select();
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
        stageSelect.transform.Find("StageNum_0").gameObject.GetComponent<Button>().Select();
    }

    public void OnClickStageNum(int number)
    {
        GameManager.Instance.StageSelect(number);
        GameManager.Instance.LoadPuzzleScene();
    }

    public void OnClickBack()
    {
        //ゲーム選択画面に切り替える
        gameSelect.SetActive(true);
        stageSelect.SetActive(false);
        gameSelect.transform.Find("NewGame").gameObject.GetComponent<Button>().Select();
    }
}
