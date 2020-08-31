using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMath
{
    public  enum DiceLevelEnum
    {
        EpicSucc,
        LimitSucc,
        HardSucc,
        Succ,
        Fail,
        EpicFail
    }
    public static int Dice3()
    {
        return Random.Range(1, 4);
    }
    public static int Dice4()
    {
        return Random.Range(1, 5);

    }
    public static int Dice6()
    {
        return Random.Range(1, 7);
    }
    public static int Dice10()
    {
        return Random.Range(0, 10);
    }
    public static int Dice20()
    {
        return Random.Range(0, 20);
    }
    public static int Dice100()
    {
        int Dice1 = Dice10();
        int Dice2 = Dice10();

        return Dice100Counting(Dice1, Dice2);
    }

    public static int RewardDice()
    {
        List<int> Dices = new List<int>();
        Dices.Add(Dice10());
        Dices.Add(Dice10());
        Dices.Add(Dice10());

        Dices.Sort();

        return Dice100Counting(Dices[0], Dices[1]);
    }

    public static int PunishmentDice()
    {
        List<int> Dices = new List<int>();
        Dices.Add(Dice10());
        Dices.Add(Dice10());
        Dices.Add(Dice10());

        Dices.Sort();
        Dices.Reverse();

        return Dice100Counting(Dices[0], Dices[1]);
    }

    public static int Dice100Counting(int LeftDice, int RightDice)
    {
        return (LeftDice == RightDice && LeftDice == 0) ? 100 : ((LeftDice * 10) + RightDice);
    }

    public static DiceLevelEnum JudgeDice(int SuccRate, int RandomResult)
    {
        if (RandomResult <= 1)
        {
            return DiceLevelEnum.EpicSucc;
        }

        if (RandomResult <= (SuccRate * 0.2f))
        {
            return DiceLevelEnum.LimitSucc;
        }

        if (RandomResult <= (SuccRate * 0.5f))
        {
            return DiceLevelEnum.HardSucc;
        }

        if (RandomResult <= (SuccRate))
        {
            return DiceLevelEnum.Succ;
        }

        if (RandomResult >= ((SuccRate >= 50) ? 100 : 96))
        {
            return DiceLevelEnum.EpicFail;
        }

        if (RandomResult > SuccRate )
        {
            return DiceLevelEnum.Fail;
        }

        return DiceLevelEnum.Succ;
    }
}
