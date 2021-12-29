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
    // ��ư ����� Ŭ��
    public AudioClip hoverSound;
    public AudioClip clickSound;

    // ����� �ҽ�
    AudioSource[] m_AudioSources;

    void Awake()
    {
        if(_instance==null)
        {
            _instance = FindObjectOfType<AudioManager>();
            // �� ��ȯ�� �Ǿ gameObject�� �������� �ʴ´�.
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            if (_instance != this) Destroy(gameObject);
        }

        // ����� �ҽ��� ��� �ִٸ� ���� ������
        if(m_AudioSources==null)
        {
            m_AudioSources = GetComponentsInChildren<AudioSource>();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        for(int i = 0; i<m_AudioSources.Length; i++)
        {
            // ���� i��° ������ҽ��� ���������� �ʴٸ�
            if(!m_AudioSources[i].isPlaying)
            {
                // i��° ������ҽ��� clip�� ����
                m_AudioSources[i].PlayOneShot(clip);
                // ����������� ��� ����
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
