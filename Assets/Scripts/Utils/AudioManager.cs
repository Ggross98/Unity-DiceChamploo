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

    private static float fadeTime = 1f;

    [Range(0f,1f)]
    private static float bgVolume = 1f, seVolume =1f;

    //private static float bgMaxVolume = 1f;

    private Coroutine fadeCoroutine = null;

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
            //Debug.Log(item.name);

        }

    }

    public void SetBGMVolume(int v)
    {
        if (v < 0) v = 0;
        if (v > 100) v = 100;

        bgVolume = v/100f;
        
        if(fadeCoroutine== null)
        {
            bgAudioSource.volume = bgVolume;
        }
    }

    public void SetSEVolume(int v)
    {
        if (v < 0) v = 0;
        if (v > 100) v = 100;

        seVolume = v/100f;

        seAudioSource.volume = seVolume;

    }

    public int GetBGMVolumeInt()
    {
        return (int)(bgVolume * 100);
    }

    public int GetSEVolumeInt()
    {
        return (int)(seVolume * 100);
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
            if (bgAudioSource.clip == _soundDictionary[audioName]) return;

            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeIn(audioName));

        }
    }

    private IEnumerator FadeIn(string audioName)
    {
        
        float delta = bgVolume / fadeTime;
        while(bgAudioSource.volume > 0)
        {
            bgAudioSource.volume -= delta * Time.deltaTime;
            yield return null;
        }
        bgAudioSource.clip = _soundDictionary[audioName];
        bgAudioSource.Play();
        while (bgAudioSource.volume < bgVolume)
        {
            bgAudioSource.volume += delta * Time.deltaTime;
            yield return null;
        }

        fadeCoroutine = null;
        yield return null;
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
