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
        this.transform.position=new Vector3(manager.player.transform.position.x, manager.player.transform.position.y+3, manager.player.transform.position.z);
    }
}
