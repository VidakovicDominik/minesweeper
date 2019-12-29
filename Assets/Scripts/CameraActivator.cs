﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActivator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.pauseMusic();
        GameManager.Instance.getFaceCamera().SetActive(true);
    }
    
}
