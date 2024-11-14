using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [Header("- Float")]
    public float bgmVolume = 0.5f; // 배경음악 볼륨 (0.0 ~ 1.0)

    [Header ("- AudioClip")]
    public AudioClip bgmClip; // 재생할 배경음악 클립
    
    // Private
    private AudioSource audioSource; // AudioSource 컴포넌트 참조

    void Start()
    {        
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기

        // AudioSource 설정
        audioSource.clip = bgmClip;
        audioSource.volume = bgmVolume;
        audioSource.loop = true; // 배경음악 반복 재생
        audioSource.playOnAwake = false; // 게임 시작 시 자동 재생 비활성화

        audioSource.Play(); // 배경음악 재생
    }
}