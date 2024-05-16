using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Spin : MonoBehaviour
{
    public static Spin instance;
    public Transform ring; 
    public int numberItem;
    public float timeRotate;
    public int numberRotate;
    public float currentTime;
    public int itemRandom;

    const float CIRCLE = 360f;
    float angleItem;
    public AnimationCurve animationCurve;

    public Transform Horled;

    void Awake()
    {
        Spin.instance = this;
    }


    private void Start()
    {
        numberItem = ShowItem.instance.items.Count;
        angleItem = CIRCLE/numberItem;
        SetPos();
    }

    private void Update()
    {
       //ShowDialog();
    }
    private void OnMouseDown()
    {
        Rotate();
        GetTxt();
    }    

    IEnumerator SpinByAnge()
    {
        float starAngle = ring.transform.eulerAngles.z;
        currentTime = 0;
        itemRandom = Random.Range(1, numberItem);
        Debug.Log(itemRandom);
        float angle = (numberRotate * CIRCLE) + angleItem * itemRandom - starAngle;

        while(currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angle * animationCurve.Evaluate(currentTime/timeRotate);
            ring.transform.eulerAngles= new Vector3(0,0,angleCurrent+starAngle);
        }
    }
    
    public void Rotate()
    {
        StartCoroutine(SpinByAnge());
    }

    public void SetPos()
    {
        for (int i = 0; i < ShowItem.instance.items.Count; i++)
        {
            Horled.GetChild(i).eulerAngles = new Vector3(0, 0, -CIRCLE/numberItem*i);
            //paren.GetChild(i).GetChild(0).GetComponent<TextMeshPro>().text = (i+1).ToString();
          

        }
    }    

    public void GetTxt()
    {
        int item = itemRandom-1;
        string txt = Horled.GetChild(item).GetChild(0).GetComponent<TextMeshPro>().text;
        UIManage.instance.SetText(txt);
    }    

    public void ShowDialog()
    {
        if (currentTime >= timeRotate)
        {
            Invoke("GetDialog", 1f);
        }    
    }    

    public void GetDialog()
    {
       
        UIManage.instance.SetDialog();
    }    
      
}
