using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    [Header("- Float")]
    public float bgmVolume = 0.5f; // ������� ���� (0.0 ~ 1.0)

    [Header ("- AudioClip")]
    public AudioClip bgmClip; // ����� ������� Ŭ��
    
    // Private
    private AudioSource audioSource; // AudioSource ������Ʈ ����

    void Start()
    {        
        audioSource = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������

        // AudioSource ����
        audioSource.clip = bgmClip;
        audioSource.volume = bgmVolume;
        audioSource.loop = true; // ������� �ݺ� ���
        audioSource.playOnAwake = false; // ���� ���� �� �ڵ� ��� ��Ȱ��ȭ

        audioSource.Play(); // ������� ���
    }
}