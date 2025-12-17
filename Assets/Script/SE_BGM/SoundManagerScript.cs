using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript Instance;

    [Header("AudioSource")]
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource SESource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// BGM再生
    /// <summary>
    public void PlayBGM(AudioClip clip,float volume=1.0f)
    {
        // すでに同じBGMが再生されている場合は何もしない
        if (BGMSource.clip==clip)
        {
            return;
        }

        //これから再生するBGMをセット
        BGMSource.clip = clip;
        //音量セット     デフォルトの音量は1.0f
        BGMSource.volume = volume;
        //BGMのループ再生を有効にする
        BGMSource.loop = true;
        //BGM再生
        BGMSource.Play();
    }

    public void StopBGM()
    {
        BGMSource.Stop();
        BGMSource.clip = null;
    }

    /// <summary>
    /// SE再生
    /// <summary>
    public void PlaySE(AudioClip clip, float volume=1.0f)
    {
        //SE再生
        //PlayOneShotは一度だけ再生する
        SESource.PlayOneShot(clip, volume);
    }
}
