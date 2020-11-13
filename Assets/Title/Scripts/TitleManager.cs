using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    //ボタンクリックでなくスペースキーで遷移するように
    //今後、続きから機能などの実装の時に戻す可能性あり

    //public GameObject canvas;

    //GameObject gameSelect;
    //GameObject stageSelect;

    //private void Start()
    //{
    //    gameSelect = canvas.transform.Find("GameSelect").gameObject;
    //    //ステージ選択画面は初期状態で隠しておく
    //    stageSelect = canvas.transform.Find("StageSelect").gameObject;
    //        //未クリアステージは選択不可に
    //    for(int i = 0; i < GameManager.Instance.StageMax; i++)
    //    {
    //        string buttonName = "StageNum_" + i.ToString();
    //        stageSelect.transform.Find(buttonName).gameObject.SetActive(GameManager.Instance.data.clearedStage[i]);
    //    }
    //    stageSelect.SetActive(false);
    //    //NewGameを選択状態にしておく
    //    gameSelect.transform.Find("NewGame").gameObject.GetComponent<Button>().Select();
    //}

    private void Update()
    {
        CheckSpaceKey();
    }

    void CheckSpaceKey()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.LoadPuzzleScene("1-1");
        }
    }


    //public void OnClickNewGame()
    //{
    //    //GameManager.Instance.nextStageKey = "1-1";
    //    GameManager.Instance.LoadPuzzleScene("1-1");
    //}

    //public void OnClickLoadGame()
    //{
    //    //ゲーム選択画面を隠してステージ選択画面に切り替える
    //    gameSelect.SetActive(false);
    //    stageSelect.SetActive(true);
    //    stageSelect.transform.Find("StageNum_0").gameObject.GetComponent<Button>().Select();
    //}

    //public void OnClickStageNum(string stageKey)
    //{
    //    //GameManager.Instance.StageSelect(stageKey);
    //    GameManager.Instance.LoadPuzzleScene(stageKey);
    //}

    //public void OnClickBack()
    //{
    //    //ゲーム選択画面に切り替える
    //    gameSelect.SetActive(true);
    //    stageSelect.SetActive(false);
    //    gameSelect.transform.Find("NewGame").gameObject.GetComponent<Button>().Select();
    //}
}
