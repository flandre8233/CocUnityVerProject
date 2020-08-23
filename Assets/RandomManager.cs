using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomManager : MonoBehaviour
{
    public static RandomManager Intance;

    void Awake()
    {
        if (Intance != null)
        {
            Destroy(gameObject);
            return;
        }
        Intance = this;
    }

    [SerializeField]
    Text OutPutResult;
    public int ActiveRandomNumber;

    public void OnClickRandomButton()
    {
        switch (ActiveRandomNumber)
        {
            case 3:
                OnClickDice3Button();
                break;
            case 4:
                OnClickDice4Button();
                break;
            case 10:
                OnClickDice10Button();
                break;
            case 100:
                OnClickDice100Button();
                break;
            case 6:
                OnClickDice6Button();
                break;
       
        }
    }

    public void OnClickDice3Button()
    {
        OutPutResult.text = "1D3 Result : " + Dice3().ToString();
    }

    public void OnClickDice4Button()
    {
        OutPutResult.text = "1D4 Result : " + Dice4().ToString();
    }

    public void OnClickDice6Button()
    {
        OutPutResult.text = "1D6 Result : " + Dice6().ToString();
    }
    public void OnClickDice10Button()
    {
        OutPutResult.text = "1D10 Result : " + Dice10().ToString();
    }
    public void OnClickDice100Button()
    {
        OutPutResult.text = "1D100 Result : " + Dice100().ToString();
    }

    public int Dice3()
    {
        return Random.Range(0, 3) + 1;
    }
    public int Dice4()
    {
        return Random.Range(0,4) + 1;
       
    }
    public int Dice6()
    {
        return Random.Range(0, 6) + 1;
    }
    public int Dice10()
    {
        return Random.Range(0, 10) + 1;
    }
    public int Dice100()
    {
        return ( (Dice10() - 1) * 10 + (Dice10() - 1 ) ) + 1 ;
    }
}
