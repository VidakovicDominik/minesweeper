using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool isMine = false;

    public Material triggeredMaterial;

    private string coordinates;

    public TextMesh textMesh;
    

    public Tile(bool isMine)
    {
        this.isMine = isMine;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void setText(string text)
    {
        textMesh.text = text;
    }

    public void setCoordinates(string coordinates)
    {
        this.coordinates = coordinates;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = triggeredMaterial;
            transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
            Debug.Log(coordinates);
            if (isMine)
            {
                Debug.Log("BOOM");
            }
        }
    }
}


