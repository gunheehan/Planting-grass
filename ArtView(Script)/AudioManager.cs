using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AudioManager>();
            return _instance;
        }
    }
    // 버튼 오디오 클립
    public AudioClip hoverSound;
    public AudioClip clickSound;

    // 오디오 소스
    AudioSource[] m_AudioSources;

    void Awake()
    {
        if(_instance==null)
        {
            _instance = FindObjectOfType<AudioManager>();
            // 씬 전환이 되어도 gameObject는 없어지지 않는다.
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            if (_instance != this) Destroy(gameObject);
        }

        // 오디오 소스가 비어 있다면 참조 시켜줌
        if(m_AudioSources==null)
        {
            m_AudioSources = GetComponentsInChildren<AudioSource>();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        for(int i = 0; i<m_AudioSources.Length; i++)
        {
            // 만약 i번째 오디오소스가 실행중이지 않다면
            if(!m_AudioSources[i].isPlaying)
            {
                // i번째 오디오소스에 clip을 실행
                m_AudioSources[i].PlayOneShot(clip);
                // 실행시켰으니 즉시 종료
                break;
            }
        }
    }

    public void PlayHoverSound()
    {
        PlaySound(hoverSound);
    }

    public void PlayClickSound()
    {
        PlaySound(clickSound);
    }

    public void Setvolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
