using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RewardPunishmentControll : SingletonMonoBehavior<RewardPunishmentControll>
{
    public InputField inputField;

    public int ExtraDiceTime {
        get {
            return int.Parse(inputField.text == ""? "0" : inputField.text);
        }
    }

    [SerializeField]
    Button[] RandomButton;


    public void OnClickRewardButton()
    {
        RandomManager.instance.Invoke("OutPutTextAni", 0);
        Invoke("SetButtonDeActive", 0);
        Invoke("SetButtonActive", RandomManager.instance.ProgressTime);
        Invoke("DisPlayDiceRewardResult", RandomManager.instance.ProgressTime);
    }

    public void OnClickPunishmentButton()
    {
        RandomManager.instance.Invoke("OutPutTextAni", 0);
        Invoke("SetButtonDeActive", 0);
        Invoke("SetButtonActive", RandomManager.instance.ProgressTime);
        Invoke("DisPlayDicePunishmentResult", RandomManager.instance.ProgressTime);
    }

    void SetButtonDeActive()
    {
        foreach (var item in RandomButton)
        {
            item.interactable = false;
        }
    }
    void SetButtonActive()
    {
        foreach (var item in RandomButton)
        {
            item.interactable = true;
        }
    }

    public void DisPlayDiceRewardResult()
    {
        RandomManager.instance.OutPutResult.text = "Result : ";
        List<int> Dices = new List<int>();
        for (int i = 0; i < 2 + ExtraDiceTime; i++)
        {
            Dices.Add(DiceMath.Dice10());
            RandomManager.instance.OutPutResult.text += Dices[i] + "  ";
        }
    
        Dices.Sort();
        if (Dices.Count > 2 && Dices.Where(x => x == 0).ToList().Count >= 2)
        {
            for (int i = 1; i < Dices.Count; i++)
            {
                if (Dices[i] == 0)
                {
                    Dices.RemoveAt(i);
                }
            }
        }

        RandomManager.instance.OutPutResult.text += " Best Result : ";
        RandomManager.instance.OutPutResult.text += Dices[0] + "  " + Dices[1] + "  ";
        RandomManager.instance.OutPutResult.text += " = " + DiceMath.Dice100Counting(Dices[0],Dices[1]);
    }

    public void DisPlayDicePunishmentResult()
    {
        RandomManager.instance.OutPutResult.text = "Result : ";
        List<int> Dices = new List<int>();

        for (int i = 0; i < 2 + ExtraDiceTime; i++)
        {
            Dices.Add(DiceMath.Dice10());
            RandomManager.instance.OutPutResult.text += Dices[i] + "  ";
        }

        Dices.Sort();

        if (! (Dices.Count >= 2 && Dices.Where(x => x == 0).ToList().Count >= 2 ) )
        {
            Dices.Reverse();
        }

        RandomManager.instance.OutPutResult.text += " Worst Result : ";
        RandomManager.instance.OutPutResult.text += Dices[0] + "  " + Dices[1] + "  ";
        RandomManager.instance.OutPutResult.text += " = " + DiceMath.Dice100Counting(Dices[0], Dices[1]);
    }

}
