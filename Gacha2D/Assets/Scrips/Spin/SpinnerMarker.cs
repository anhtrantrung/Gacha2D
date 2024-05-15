using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpinnerMarker : MonoBehaviour
{
    public GameObject itemStop;
    public static SpinnerMarker instance;
    public TextMeshPro item;
    public string number;

    protected void Awake()
    {
        SpinnerMarker.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.number = collision.name;
        itemStop = collision.gameObject;

        //item = itemStop.GetComponent<TextMeshPro>();
        //Debug.Log(item.text);
    }
}
