using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public static Spin instance;
    public TextMeshPro item;
    public TextMeshPro itemUI;
    public Transform ring;
    public float speed = 0f;
    public float maxSpeed ;
    public float slowDown;
    public string nameItem;
    public bool isSpin;

     void Awake()
    {
        Spin.instance = this;
    }

    private void OnMouseDown()
    {
        StarSpin();
        isSpin = true;
    }
    private void FixedUpdate()
    {
        Spinning();
    }
    public void StarSpin()
    {
        maxSpeed = Random.Range(6f, 9f);
        slowDown = Random.Range(0.02f, 0.05f);
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

    public void Stop(TextMeshPro txt)
    {
        if(speed==0 && isSpin)
        {
            isSpin = false;
            itemUI.text ="Item: "+ txt.text;
        }    
    }       
}
