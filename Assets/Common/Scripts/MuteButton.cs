using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Text text;
    bool isMute;

    private void Start()
    {
        isMute = BGMManager.Instance.isMute;
        text.text = isMute ? "BGM OFF[M]" : "BGM ON[M]";
    }

    public void OnClickMuteButton()
    {
        isMute = !isMute;
        BGMManager.Instance.SwitchMute(isMute);
        //ボタン表示を変える
        text.text = isMute ? "BGM OFF[M]" : "BGM ON[M]";
    }
}
