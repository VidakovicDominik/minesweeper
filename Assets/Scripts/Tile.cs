using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool isMine = false;

    public bool isLoner = false;

    public bool isTriggered = false;

    public Material triggeredMaterial;

    public Coordinates coordinates;

    public TextMesh textMesh;


    public Tile(bool isMine)
    {
        this.isMine = isMine;
    }

    public void setText(string text)
    {
        textMesh.text = text;
    }

    public void setCoordinates(Coordinates coordinates)
    {
        this.coordinates = coordinates;
    }

    public void clearField()
    {
        if (!isTriggered)
        {
            gameObject.GetComponent<MeshRenderer>().material = triggeredMaterial;
            transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
            transform.GetChild(0).gameObject.SetActive(true);
            isTriggered = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(coordinates.getX()+","+coordinates.getY());
            if (!isTriggered)
            {
                AudioManager.Instance.playClick();
                clearField();
                if (isMine)
                {
                    Debug.Log("BOOM");
                    GameManager.Instance.initGameOver(false);
                }
                else if (isLoner)
                {
                    GameManager.Instance.minefieldManager.cascade(coordinates);
                }
            }
        }
    }
}


