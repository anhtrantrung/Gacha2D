using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using TMPro;

public class ShowItem : MonoBehaviour
{
    public static ShowItem instance;
    public Transform hodler;
    public TextMeshPro itemData;
    [SerializeField] List<Transform> items = new List<Transform>();

    protected void Awake()
    {
        ShowItem.instance = this;
    }

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

    private void FixedUpdate()
    {
        LoadItem();
    }

    public void LoadItem()
    {
        foreach (Transform item in items)
        {
            if (item.name == SpinnerMarker.instance.itenName)
            {
                itemData = item.GetComponent<TextMeshPro>();
                Spin.instance.Stop(itemData);
            }
        }

    }
}
