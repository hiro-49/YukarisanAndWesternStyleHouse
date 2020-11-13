using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : SingletonBehaviour<BGMManager>
{
    AudioSource audio;
    AudioClip clip;

    public bool isMute;

    public void Init()
    {
        audio = gameObject.AddComponent<AudioSource>();
        clip = Resources.Load("BGM/game_maoudamashii_6_dangeon22") as AudioClip;
        audio.clip = clip;
        audio.loop = true;
        audio.volume = 0.2f;
        audio.Play();
    }

    //ミュートONとOFFを切り替える
    public void SwitchMute(bool isMute)
    {
        this.isMute = isMute;
        if (isMute)
        {
            audio.volume = 0f;
        }
        else
        {
            audio.volume = 0.2f;
        }
    }

}
