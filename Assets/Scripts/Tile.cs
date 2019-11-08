using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType tyleType=TileType.HINT;

    public bool triggered=false;

    public TextMesh textMesh;

    public Material triggeredMaterial;

    public Tile(TileType type)
    {
        this.tyleType = type;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.gameObject.CompareTag("Player"))
            TriggerTile();
    }

    public void TriggerTile()
    {
        triggered = true;
        this.GetComponent<Renderer>().material = triggeredMaterial;
        transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
    }

    public bool isTriggered()
    {
        return triggered;
    }

    public TileType getType()
    {
        return tyleType;
    }
}

public enum TileType
{
    MINE,HINT
}
