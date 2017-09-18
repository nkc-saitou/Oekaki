﻿using System.Collections;
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

        //Pen
        penSource = gameObject.AddComponent<AudioSource>();
        penSource.volume = 0.7f;
        penSource.loop = true;
        penSource.clip = penSound;
    }

    //-------------------------------------------------------------------------
    //  Private
    //-------------------------------------------------------------------------

    //AudioClip
    [SerializeField]
    AudioClip[] bgmSound;
    [SerializeField]
    AudioClip[] seSound;
    [SerializeField]
    AudioClip penSound;

    //AudioSource
    AudioSource bgmSource;
    AudioSource[] seSource = new AudioSource[3];
    AudioSource penSource;

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

    public void PlayBack_Pen()
    {
        if(!penSource.isPlaying) penSource.Play();
    }
    public void PlayStop_Pen() { penSource.Stop(); }

    //-------------------------------------------------------------------------
    //  enum
    //-------------------------------------------------------------------------
    public enum BGM
    {
        Title = 0,
        Game
    }

    public enum SE
    {
    }
}
