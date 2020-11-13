using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    AudioSource audio;
    AudioClip clip;
    public void Init()
    {
        audio = gameObject.AddComponent<AudioSource>();
        clip = Resources.Load("BGM/game_maoudamashii_6_dangeon22") as AudioClip;
        audio.clip = clip;
        audio.loop = true;
        audio.volume = 0.2f;
        audio.Play();
    }
}
