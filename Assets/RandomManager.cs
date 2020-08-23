using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomManager : SingletonMonoBehavior<RandomManager>
{
    [SerializeField]
    Button RandomButton;
    [SerializeField]
    public Text OutPutResult;
    public int ActiveRandomNumber;

    public float ProgressTime;
    public int RandomTimes;

    public void UpdateRandomTimes(int Val)
    {
        RandomTimes = Val + 1;
    }

    private void Start()
    {
        RandomButton.interactable = false;
        OutPutResult.text = "";
    }

    void ResetButton()
    {
        RandomButton.interactable = true;
    }

    public void OnClickRandomButton()
    {
        Invoke("OutPutTextAni", 0);
        Invoke("ResetButton", ProgressTime);

        RandomButton.interactable = false;
        switch (ActiveRandomNumber)
        {
            case 3:
                OnClickDice3Button();
                break;
            case 4:
                OnClickDice4Button();
                break;
            case 6:
                OnClickDice6Button();
                break;
            case 10:
                OnClickDice10Button();
                break;
            case 20:
                OnClickDice20Button();
                break;
            case 100:
                OnClickDice100Button();
                break;
        }
    }

    private void OnClickDice3Button()
    {
        Invoke("DisPlayDice3Result", ProgressTime);
    }

    private void OnClickDice4Button()
    {
        Invoke("DisPlayDice4Result", ProgressTime);

    }

    private void OnClickDice6Button()
    {
        Invoke("DisPlayDice6Result", ProgressTime);
    }

    private void OnClickDice10Button()
    {
        Invoke("DisPlayDice10Result", ProgressTime);
    }
    private void OnClickDice20Button()
    {
        Invoke("DisPlayDice20Result", ProgressTime);
    }

    private void OnClickDice100Button()
    {
        Invoke("DisPlayDice100Result", ProgressTime);
    }

    public void DisPlayDice3Result()
    {
        OutPutResult.text = RandomTimes + "D3 Result : ";
        int DicesResult = 0;
        for (int i = 0; i < RandomTimes; i++)
        {
            int Dice = DiceMath.Dice3();
            DicesResult += Dice;
            OutPutResult.text += Dice + "  ";
        }

        OutPutResult.text +=  " = " + DicesResult;
    }

    public void DisPlayDice4Result()
    {
        OutPutResult.text = RandomTimes + "D4 Result : ";
        int DicesResult = 0;
        for (int i = 0; i < RandomTimes; i++)
        {
            int Dice = DiceMath.Dice4();
            DicesResult += Dice;
            OutPutResult.text += Dice + "  ";
        }

        OutPutResult.text += " = " + DicesResult;
    }

    public void DisPlayDice6Result()
    {
        OutPutResult.text = RandomTimes + "D6 Result : ";
        int DicesResult = 0;
        for (int i = 0; i < RandomTimes; i++)
        {
            int Dice = DiceMath.Dice6();
            DicesResult += Dice;
            OutPutResult.text += Dice + "  ";
        }

        OutPutResult.text += " = " + DicesResult;
    }
    public void DisPlayDice10Result()
    {
        OutPutResult.text = RandomTimes + "D10 Result : ";
        int DicesResult = 0;
        for (int i = 0; i < RandomTimes; i++)
        {
            int Dice = DiceMath.Dice10();
            DicesResult += Dice;
            OutPutResult.text += Dice + "  ";
        }

        OutPutResult.text += " = " + DicesResult;
    }
    public void DisPlayDice20Result()
    {
        OutPutResult.text = RandomTimes + "D20 Result : ";
        int DicesResult = 0;
        for (int i = 0; i < RandomTimes; i++)
        {
            int Dice = DiceMath.Dice20();
            DicesResult += Dice;
            OutPutResult.text += Dice + "  ";
        }

        OutPutResult.text += " = " + DicesResult;
    }
    public void DisPlayDice100Result()
    {
        OutPutResult.text = RandomTimes + "D100 Result : ";
        int DicesResult = 0;
        for (int i = 0; i < RandomTimes; i++)
        {
            int Dice = DiceMath.Dice100();
            DicesResult += Dice;
            OutPutResult.text += Dice + "  ";
        }

        OutPutResult.text += " = " + DicesResult;
    }

    public void OutPutTextAni()
    {
        OutPutResult.text = "Processing......";
    }

}
