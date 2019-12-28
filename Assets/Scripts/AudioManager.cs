using UnityEngine;
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public AudioSource musicAudioSource;
    public AudioSource clickAudioSource;
    public AudioSource timelineAudioSource;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AudioManager();
            }
            return _instance;
        }
    }

    void Start()
    {
        AudioSource[] audios = Camera.main.GetComponents<AudioSource>();
        audios[0].volume = PlayerPrefs.GetFloat("sfx");
        audios[1].volume = PlayerPrefs.GetFloat("music");
    }

}