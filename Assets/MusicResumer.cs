using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicResumer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.playMusic();
        gameObject.SetActive(false);
    }
}
