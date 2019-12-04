using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public GameManager manager;

    void Start()
    {
        manager = GameManager.Instance;
    }

    void FixedUpdate()
    {
        this.transform.position=new Vector3(manager.playerPrefab.transform.position.x, manager.playerPrefab.transform.position.y+3, manager.playerPrefab.transform.position.z);
    }
}
