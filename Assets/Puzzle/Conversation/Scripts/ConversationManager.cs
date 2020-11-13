using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ConversationManager : MonoBehaviour
{
    public GameObject leftCharacter;
    public GameObject rightCharacter;
    public GameObject speakerName;
    public GameObject talk;

    Text nameText;
    Text talkText;
    List<string[]> talkData;    //会話データ

    //会話データ用定数
    const int Speaker = 0;
    const int Difference = 1;
    const int Place = 2;
    const int Direction = 3;
    const int DispName = 4;
    const int Contents = 5;


    private void Awake()
    {
        nameText = speakerName.GetComponent<Text>();
        talkText = talk.GetComponent<Text>();
    }

    IEnumerator TalkCoroutine()
    {
        for (int i = 0; i < talkData.Count; i++)
        {
            //キャラ全員暗くする
            leftCharacter.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f);
            rightCharacter.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f);

            //発言キャラ入れ替え&表示
            GameObject speaker;
            //キャラ位置変更
            switch (talkData[i][Place])
            {
                case "1":
                    speaker = rightCharacter;
                    break;
                case "-1":
                    speaker = leftCharacter;
                    break;
                default:
                    speaker = null;
                    break;
            }
            //キャラがいる時編集
            if (speaker != null)
            {
                Image image = speaker.GetComponent<Image>();
                image.enabled = true;
                image.color = Color.white;  //キャラ表示を明るくする
                image.sprite = Resources.Load<Sprite>("Speakers/" + talkData[i][Speaker] + "_" + talkData[i][Difference]);  //キャラ画像読み込み
                speaker.GetComponent<RectTransform>().localScale = new Vector3(Convert.ToInt32(talkData[i][Direction]), 1f,1f);    //向き変更
            }

            //名前と会話表示
            //デフォルト以外デバッグしてないよ
            switch (talkData[i][Contents])
            {
                case "/dispChar":
                    continue;
                case "/hideChar":
                    if (talkData[i][Place] == "1") rightCharacter.GetComponent<Image>().enabled = false;
                    else if (talkData[i][Place] == "-1") leftCharacter.GetComponent<Image>().enabled = false;
                    continue;
                default:
                    nameText.text = talkData[i][DispName];
                    talkText.text = talkData[i][Contents];
                    Debug.Log(talkData[i][Contents]);
                    break;
            }
            Resources.UnloadUnusedAssets();
            //キー入力待ち
            yield return StartCoroutine(WaitSpaceOrEnterKey());
        }
        EndConversation();
    }

    IEnumerator WaitSpaceOrEnterKey()
    {
        while(!(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return)))
        {
            yield return null;
        }
        yield return null;
    }

    void EndConversation()
    {
        gameObject.SetActive(false);    //会話UIを非表示に
    }

    //会話を開始する
    public IEnumerator StartConversation(List<string[]> data)
    {
        //初期化
        gameObject.SetActive(true);
        talkData = data;
        rightCharacter.GetComponent<Image>().enabled = false;
        leftCharacter.GetComponent<Image>().enabled = false;
        yield return StartCoroutine(TalkCoroutine());
    }

}
