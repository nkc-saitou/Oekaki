using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //シングルトン
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        //BGM
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.volume = 0.3f;
        bgmSource.loop = true;

        //SE
        for(int i = 0; i < seSource.Length; i++)
        {
            seSource[i] = gameObject.AddComponent<AudioSource>();
            seSource[i].volume = 0.6f;
            seSource[i].loop = false;
        }
        
    }

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    //AudioClip
    [SerializeField]
    AudioClip[] bgmSound;
    [SerializeField]
    AudioClip[] seSound;

    //AudioSource
    AudioSource bgmSource;
    AudioSource[] seSource = new AudioSource[3];

    //-------------------------------------------------------------------------
    //  音再生
    //-------------------------------------------------------------------------

    public void PlayBack_BGM(int no)
    {
        bgmSource.clip = bgmSound[no];
        bgmSource.Play();
    }

    public void PlayBack_SE(int no)
    {
        foreach(AudioSource audio in seSource)
        {
            if(!audio.isPlaying)
            {
                audio.clip = seSound[no];
                audio.Play();

                break;
            }
        }
    }
}
