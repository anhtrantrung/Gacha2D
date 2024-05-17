using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public static Spin instance;
    public AnimationCurve animationCurve;
    public Transform ring;
    public Transform Horled;

    public int numberItem;
    public float timeRotate;
    public int numberRotate;
    public float currentTime;
    public int itemRandom;

    public const float CIRCLE = 360f;
    public float angleItem;

    public bool isSpinning;
    private bool isPopupShown;

    void Awake()
    {
        Spin.instance = this;
    }

    private void Start()
    {
        numberItem = ShowItem.instance.items.Count;
        angleItem = CIRCLE / numberItem;
        SetPos();
        isSpinning = false;
        isPopupShown = false;
    }

    private void Update()
    {
        Stop();
    }

    private void OnMouseDown()
    {
        Rotate();
        GetTxt();
    }

    IEnumerator SpinByAnge()
    {
        isSpinning = true;
        isPopupShown = false;

        float starAngle = ring.transform.eulerAngles.z;
        currentTime = 0;
        itemRandom = Random.Range(1, numberItem);
        Debug.Log(itemRandom);
        float angle = (numberRotate * CIRCLE) + angleItem * itemRandom - starAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float easedTime = EaseOutCubic(currentTime / timeRotate);
            float angleCurrent = Mathf.Lerp(0, angle, easedTime);
            ring.transform.eulerAngles = new Vector3(0, 0, angleCurrent + starAngle+-5f);
        }

        Invoke("ShowDialog", 0.01f);
     
    }

    public float EaseOutCubic(float t)
    {
        return t * (2 - t);
    }

    public void Rotate()
    {
        StartCoroutine(SpinByAnge());
    }

    public void SetPos()
    {
        for (int i = 0; i < ShowItem.instance.items.Count; i++)
        {
            Horled.GetChild(i).eulerAngles = new Vector3(0, 0, -CIRCLE / numberItem * i);
        }
    }

    public void GetTxt()
    {
        int item = itemRandom - 1;
        string txt = Horled.GetChild(item).GetChild(0).GetComponent<TextMeshPro>().text;
        UIManage.instance.SetText(txt);
    }

    public void ShowDialog()
    {
        if (!isPopupShown)
        {
            UIManage.instance.DialogTrue();
            isPopupShown = true;
        }
    }

    public void Stop()
    {
        if (currentTime >= timeRotate)
        {
            isSpinning = false;
        }
    }

    public void ClosePopup()
    {
        UIManage.instance.DialogFalse();
    }
}