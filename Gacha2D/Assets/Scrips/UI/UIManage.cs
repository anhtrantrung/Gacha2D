using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    public static UIManage instance;
    public Text rewardTxt;
    public GameObject dialogPn;

    void Awake()
    {
        UIManage.instance = this;
    }

    private void Start()
    {
        dialogPn.SetActive(false);
    }
    public void SetText( string itemTxt)
    {
        if(rewardTxt != null) 
        rewardTxt.text = itemTxt;
    }    

    public void DialogTrue()
    {
        if (dialogPn != null)
        {
            dialogPn.SetActive(true);
        }    
       
    }

    public void DialogFalse()
    {
        if (dialogPn != null)
        {
            dialogPn.SetActive(false);
        }

    }
   
}
