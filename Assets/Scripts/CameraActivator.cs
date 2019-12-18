using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActivator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.getFaceCamera().SetActive(true);
        gameObject.SetActive(false);
    }
    
}
