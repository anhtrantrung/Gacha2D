using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Transform itemObj;
    //public TextMeshPro item;
    public Transform ring;
    public float speed = 0f;
    public float maxSpeed ;
    public float slowDown;
    public string nameItem;

    private void OnMouseDown()
    {
        StarSpin();
    }
    private void FixedUpdate()
    {
        Spinning();
        Stop();
        FindName();
    }
    public void StarSpin()
    {
        maxSpeed = Random.Range(4, 7);
        speed = maxSpeed;
    }    

    public void Spinning()
    {
        if(speed >0)
        {
            ring.Rotate(0, 0, speed);
            speed-= slowDown;
        }   
        else
        {
            speed = 0f;
        }    
        
    }    

    public void Stop()
    {
        if(speed==0)
        {
            //nameItem = SpinnerMarker.instance.number;
            //Debug.Log(nameItem);

            //itemObj = SpinnerMarker.instance.itemStop;
            //item = itemObj.GetComponent<TextMeshPro>();
            //Debug.Log(item.text);
        }    
    }    

    public void FindName()
    {
        itemObj = transform.Find(SpinnerMarker.instance.number);
        Debug.Log(itemObj.name);
    }    
}
