using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using TMPro;

public class ShowItem : MonoBehaviour
{
    public Transform hodler;
    public TextMeshPro itemData;
    [SerializeField] List<Transform> items = new List<Transform>();

    private void Reset()
    {
        LoadHodler();

    }

    public void LoadHodler()
    {
        if (hodler != null) return;
        hodler = transform.Find("Horled");

        foreach (Transform item in hodler)
        {
            items.Add(item);
        }
    }

    private void Start()
    {
        LoadItem();
    }

    public void LoadItem()
    {
        foreach (Transform item in items)
        {
            itemData = item.GetComponent<TextMeshPro>();
        }

    }
}
