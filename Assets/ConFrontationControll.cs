﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConFrontationControll : SingletonMonoBehavior<ConFrontationControll>
{
    [SerializeField]
    InputField OurSideInputField;
    [SerializeField]
    InputField OpposSideInputField;

    [SerializeField]
    Text ResultText;

    public Button RandomButton;

    public float RandomTimes;


    private void Start()
    {
        RandomButton.interactable = false;
        ResultText.text = "";
    }

    public void OnClickResultButton()
    {
        RandomButton.interactable = false;
        Invoke("OutPutTextAni" , 0);
        Invoke("OutputResult", RandomTimes);
        Invoke("ResetButton", RandomTimes);
    }

    void ResetButton()
    {
        RandomButton.interactable = true;
    }

    public void OutputResult()
    {
        int OurSideVal = int.Parse(OurSideInputField.text);
        int OpposSideVal = int.Parse(OpposSideInputField.text);

        int PassVal = (((OurSideVal - OpposSideVal) * 5) + 50);

        if (PassVal >= 100)
        {
            ResultText.text = "100% Pass, No need to roll dice";
            return;
        }
        else if (PassVal <= 0)
        {
            ResultText.text = "100% fail pass, No need to roll dice";
            return; 
        }

        int randomDice = DiceMath.Dice100();
        ResultText.text = "Request Below " + PassVal + "% , Dice Result :  = " + randomDice + "% :" + (randomDice <= PassVal ? "Passed !" : "Not Passed !");
    }

    public void OutPutTextAni()
    {
        ResultText.text = "Processing......";
    }


}