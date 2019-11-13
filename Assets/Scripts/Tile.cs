using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool isMine = false;

    public bool isLoner = false;

    public bool isTriggered = false;

    public Material triggeredMaterial;

    public string coordinates;

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

    public void clearField()
    {
        gameObject.GetComponent<MeshRenderer>().material = triggeredMaterial;
        transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
        isTriggered = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(coordinates);
            if (isMine)
            {
                Debug.Log("BOOM");
            }
            else if(!isTriggered)
            {
                GameManager.Instance.cascade(int.Parse(coordinates.Split(',')[0]), int.Parse(coordinates.Split(',')[1]));
            }
        }
    }
}


