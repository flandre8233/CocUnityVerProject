using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RewardPunishmentControll : SingletonMonoBehavior<RewardPunishmentControll>
{
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
        Dices.Add(DiceMath.Dice10());
        Dices.Add(DiceMath.Dice10());
        Dices.Add(DiceMath.Dice10());

        RandomManager.instance.OutPutResult.text += Dices[0] + "  ";
        RandomManager.instance.OutPutResult.text += Dices[1] + "  ";
        RandomManager.instance.OutPutResult.text += Dices[2] + "  ";
        Dices.Sort();
        RandomManager.instance.OutPutResult.text += " Best Result : " + Dices[0] + "  " + Dices[1] + " = " + DiceMath.Dice100Counting(Dices[0],Dices[1]);
    }

    public void DisPlayDicePunishmentResult()
    {
        RandomManager.instance.OutPutResult.text = "Result : ";
        List<int> Dices = new List<int>();
        Dices.Add(DiceMath.Dice10());
        Dices.Add(DiceMath.Dice10());
        Dices.Add(DiceMath.Dice10());

        RandomManager.instance.OutPutResult.text += Dices[0] + "  ";
        RandomManager.instance.OutPutResult.text += Dices[1] + "  ";
        RandomManager.instance.OutPutResult.text += Dices[2] + "  ";
        Dices.Sort();
        Dices.Reverse();
        RandomManager.instance.OutPutResult.text += " Worst Result : " + Dices[0] + "  " + Dices[1] + " = " + DiceMath.Dice100Counting(Dices[0], Dices[1]);
    }

}
