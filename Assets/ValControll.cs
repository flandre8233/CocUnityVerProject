using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValControll : MonoBehaviour
{
    public ValRandomBase motherBase;
    public int RandomType;

    public int NumberVal;
    Text ViewText;
    private void Start()
    {
        ViewText = GetComponent<Text>();
        StartRandom();
    }

    public void StartRandom( )
    {
        switch (RandomType)
        {
            case 1: // 3D6
                int Dice1 = DiceMath.Dice6();
                int Dice2 = DiceMath.Dice6();
                int Dice3 = DiceMath.Dice6();

                NumberVal = Dice1 + Dice2 + Dice3;
                NumberVal *= 5;

                break;
            case 2: // 2D6 + 6
                int Dice4 = DiceMath.Dice6();
                int Dice5 = DiceMath.Dice6();

                NumberVal = Dice4 + Dice5 + 6;
                NumberVal *= 5;
                break;
            default:
                break;
        }

        ViewText.text = NumberVal.ToString();
    }
}
