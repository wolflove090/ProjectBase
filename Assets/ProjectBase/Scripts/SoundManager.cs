using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 再生したいサウンドをenumで指定する
    // パスがEnumの値名になる
    public enum Se
    {
        None, // 無音
    }

    // 再生したいサウンドをenumで指定する
    // パスがEnumの値名になる
    public enum Bgm
    {
        None,
    }

    static SoundManager _SingletonValue;
    static SoundManager _Singleton
    {
        get
        {
            return _SingletonValue;
        }
        set
        {
            _SingletonValue = value;
            _SingletonValue._Initialize();
        }
    }

    AudioSource[] _SeAudio = new AudioSource[10];
    AudioSource _BgmAudio;

    Dictionary<SoundManager.Se, AudioClip> _SeDic = new Dictionary<Se, AudioClip>();
    Dictionary<SoundManager.Bgm, AudioClip> _BgmDic = new Dictionary<Bgm, AudioClip>();

    // --------------------
    // Public Static
    // --------------------

    // bootなどで実行する
    static public void Init()
    {
        var obj = new GameObject("SoundManager");
        var manager = obj.AddComponent<SoundManager>();
        _Singleton = manager;
        GameObject.DontDestroyOnLoad(obj);
    }

    static public void PlaySe(Se se)
    {
        if(_Singleton == null)
            _Singleton = new SoundManager();

        _Singleton._PlaySe(se);
    }

    static public void PlayBgm(Bgm bgm)
    {
        if(_Singleton == null)
            _Singleton = new SoundManager();

        _Singleton._PlayBgm(bgm);
    } 

    // --------------------
    // Private
    // --------------------

    /* ------------------------------ 
     * _Initialize
     * ------------------------------ */
    void _Initialize()
    {
        this._SeDic = new Dictionary<Se, AudioClip>();
        this._BgmDic = new Dictionary<Bgm, AudioClip>();

        // SEの格納
        foreach(Se se in Enum.GetValues(typeof(SoundManager.Se)))
        {
            Debug.Log(se);
            var path = this._GetSePath(se);
            Debug.Log(path);
            var clip = Resources.Load<AudioClip>(path);
            Debug.Log(clip);
            this._SeDic.Add(se, clip);
        }

        // BGMの格納
        foreach(Bgm bgm in Enum.GetValues(typeof(SoundManager.Bgm)))
        {
            var path = this._GetBgmPath(bgm);
            Debug.Log(path);
            var clip = Resources.Load<AudioClip>(path);
            Debug.Log(clip);
            this._BgmDic.Add(bgm, clip);
        }
    }

    /* ------------------------------ 
     * _GetSePath
     * ------------------------------ */
    string _GetSePath(Se type)
    {
        return $"Sounds/Ses/{Enum.GetName(typeof(Se), type)}";
    }

    /* ------------------------------ 
     * _GetBgmPath
     * ------------------------------ */
        string _GetBgmPath(Bgm type)
    {
        return $"Sounds/Bgms/{Enum.GetName(typeof(Bgm), type)}";
    }
    
    /* ------------------------------ 
     * _PlaySe
     * ------------------------------ */
    void _PlaySe(Se se)
    {
        // 空いているAudioSourceを検索
        AudioSource audio = this._GetSeAudioSource();

        // 空いているものが無かった
        if(audio == null)
            return;

        if(this._SeDic.ContainsKey(se))
        {
            audio.clip = this._SeDic[se];
        }   

        Debug.Log("Sound Play");
        audio.Play();
    }

    /* ------------------------------ 
     * _PlayBgm
     * ------------------------------ */
    void _PlayBgm(Bgm bgm)
    {
        if(this._BgmAudio == null)
            this._BgmAudio = gameObject.AddComponent<AudioSource>() as AudioSource;

        if(this._BgmDic.ContainsKey(bgm))
            this._BgmAudio.clip = this._BgmDic[bgm];

        Debug.Log("Sound Play");
        this._BgmAudio.Play();
        this._BgmAudio.loop = true;
    }

    /* ------------------------------ 
     * _GetSeAudioSource
     * 空いているAudioSourceを検索
     * ------------------------------ */
    AudioSource _GetSeAudioSource()
    {
        for(int i = 0; i < this._SeAudio.Length; i++)
        {
            // 対象がNullなら新規作成して抜ける
            if(this._SeAudio[i] == null)
            {
                this._SeAudio[i] = gameObject.AddComponent<AudioSource>() as AudioSource;
                return this._SeAudio[i];
            }

            // 対象が再生していないなら取得して抜ける
            if(!this._SeAudio[i].isPlaying)
                return this._SeAudio[i];
        }

        return null;
    }
}