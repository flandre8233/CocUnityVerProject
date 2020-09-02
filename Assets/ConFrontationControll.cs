using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] Toggle[] MEtoggles;
    [SerializeField] Toggle[] THEIRtoggles;
    [SerializeField] InputField MEinputField;
    [SerializeField] InputField THEIRinputField;


    int GetDiceType (Toggle[] toggles) {
        for (int i = 0; i < toggles.Length; i++)
        {
            if(toggles[i].isOn)
            {
                return i + 1;
            }
        }
        return 0;
    }
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

    public int DiceRewardResult(int ExtraDice , ref string Reason)
    {
        List<int> Dices = new List<int>();
        Reason = "";
        for (int i = 0; i < 2 + ExtraDice; i++)
        {
            Dices.Add(DiceMath.Dice10());
            Reason += Dices[i] + " ";
        }

        if (Dices.Count > 2 && Dices.Where(x => x == 0).ToList().Count >= 2)
        {
            Dices.RemoveAll(x => x == 0);
            Dices.Add(0);
        }
        Dices.Sort();

        return DiceMath.Dice100Counting(Dices[0], Dices[1]);
    }

    public int DicePunishmentResult(int ExtraDice, ref string Reason)
    {
        List<int> Dices = new List<int>();
        Reason = "";

        for (int i = 0; i < 2 + ExtraDice; i++)
        {
            Dices.Add(DiceMath.Dice10());
            Reason += Dices[i] + " ";
        }

        Dices.Sort();

        if (!(Dices.Count >= 2 && Dices.Where(x => x == 0).ToList().Count >= 2))
        {
            Dices.Reverse();
        }

        return DiceMath.Dice100Counting(Dices[0], Dices[1]);
    }


    public void OutputResult()
    {
        string MEReason = "";
        string THEIRReason = "";


        int OurSideVal = int.Parse(OurSideInputField.text);
        int OpposSideVal = int.Parse(OpposSideInputField.text);

        int OurRandomResult = 0 ;

        int METype = GetDiceType(MEtoggles);
        int THEIRType = GetDiceType(THEIRtoggles);
        if (METype == 0)
        {
            OurRandomResult = DiceMath.Dice100();
        }
        else if (METype == 1)
        {
            int ExtraDice = int.Parse(MEinputField.text == "" ? "0" : MEinputField.text);
            OurRandomResult = DiceRewardResult(ExtraDice , ref MEReason);
        }
        else
        {
            int ExtraDice = int.Parse(MEinputField.text == "" ? "0" : MEinputField.text);
            OurRandomResult = DicePunishmentResult(ExtraDice, ref MEReason);
        }

        int OpposRandomResult = 0;

        if (THEIRType == 0)
        {
            OpposRandomResult = DiceMath.Dice100();
        }
        else if (THEIRType == 1)
        {
            int ExtraDice = int.Parse(THEIRinputField.text == "" ? "0" : THEIRinputField.text);
            OpposRandomResult = DiceRewardResult(ExtraDice, ref THEIRReason);
        }
        else
        {
            int ExtraDice = int.Parse(THEIRinputField.text == "" ? "0" : THEIRinputField.text);
            OpposRandomResult = DicePunishmentResult(ExtraDice, ref THEIRReason);
        }



        DiceMath.DiceLevelEnum OurJudge = DiceMath.JudgeDice(OurSideVal, OurRandomResult);
        DiceMath.DiceLevelEnum OpposJudge = DiceMath.JudgeDice(OpposSideVal, OpposRandomResult);

        if (OurJudge < OpposJudge)
        {
            ResultText.text = "Dice Result : = " + MEReason + OurJudge + " " + OurRandomResult + " VS " + THEIRReason + OpposJudge + " " + OpposRandomResult +""+ ", Passed !";
            return;
        }
        else if (OurJudge > OpposJudge)
        {
            ResultText.text = "Dice Result : = " + MEReason + OurJudge + " " + OurRandomResult + " VS " + THEIRReason + OpposJudge + " " + OpposRandomResult  + ", Not Passed !";

            return;
        }
        else
        {
            if (OurSideVal > OpposSideVal)
            {
                ResultText.text = "Dice Result : = Same DiceLevel, " + MEReason + ": " + OurRandomResult + " VS " + THEIRReason + ": " + OpposRandomResult + ", Passed !";
                return;
            }
            else if (OurSideVal < OpposSideVal)
            {
                ResultText.text = "Dice Result : = Same DiceLevel, " + MEReason + ": " + OurRandomResult + " VS " + THEIRReason + ": "+ OpposRandomResult  + ", Not Passed !";
                return;
            }
            else
            {
                OutputResult();
            }
        }

    }

    public void OutputResult_6th()
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

