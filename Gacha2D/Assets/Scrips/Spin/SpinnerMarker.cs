using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpinnerMarker : MonoBehaviour
{
    public static SpinnerMarker instance;
    public GameObject itemStop; 
    public TextMeshPro item;
    public string itenName;

    protected void Awake()
    {
        SpinnerMarker.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.itenName = collision.name;
        itemStop = collision.gameObject;
    }
}
