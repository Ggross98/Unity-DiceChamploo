using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: SingletonTemplate<AudioManager>
{

   
    /// <summary>
    /// 将声音放入字典中，方便管理
    /// </summary>
    private Dictionary<string, AudioClip> _soundDictionary;

    //背景音乐和音效的音频源
    //private AudioSource[] audioSources;
    private AudioSource bgAudioSource;
    private AudioSource seAudioSource;




    private void Awake()
    {

        //加载资源存的所有音频资源

        LoadAudio();

        //获取音频源
        //audioSources = this.GetComponents<AudioSource>();

        //背景音乐
        bgAudioSource = gameObject.AddComponent<AudioSource>();

        bgAudioSource.playOnAwake = true;

        bgAudioSource.loop = true;

        //音效
        seAudioSource = gameObject.AddComponent<AudioSource>();

        seAudioSource.playOnAwake = false;

        seAudioSource.loop = false;

    }


    private void LoadAudio()
    {

        //初始化字典

        _soundDictionary = new Dictionary<string, AudioClip>();

        //本地加载 

        AudioClip[] audioArray = Resources.LoadAll<AudioClip>("Audio");

        //存放到字典

        foreach (AudioClip item in audioArray)
        {

            _soundDictionary.Add(item.name, item);
            Debug.Log(item.name);

        }

    }


    /// <summary>
    /// 从头播放bgm
    /// 如果要播放的就是当前bgm，则不进行操作
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayBGM(string audioName)

    {

        if (_soundDictionary.ContainsKey(audioName))

        {

            if (bgAudioSource.clip == _soundDictionary[audioName]) return;

            bgAudioSource.clip = _soundDictionary[audioName];

            bgAudioSource.Play();

        }

    }

    /// <summary>
    /// 切换bgm并从头播放
    /// </summary>
    /// <param name="audioName"></param>
    public void ChangeBGM(string audioName)
    {
        if (_soundDictionary.ContainsKey(audioName))

        {
            bgAudioSource.clip = _soundDictionary[audioName];

            bgAudioSource.Play();

        }
    }


    public void PlaySoundEffect(string audioEffectName)

    {

        if (_soundDictionary.ContainsKey(audioEffectName))

        {

            seAudioSource.clip = _soundDictionary[audioEffectName];

            seAudioSource.Play();

        }

    }

    
}
