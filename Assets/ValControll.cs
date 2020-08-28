using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValControll : MonoBehaviour
{
    public ValRandomBase motherBase;

    public int NumberVal;
    Text ViewText;
    private void Start()
    {
        ViewText = GetComponent<Text>();
        StartRandom();
    }

    public void StartRandom()
    {
        int Dice1 = DiceMath.Dice6();
        int Dice2 = DiceMath.Dice6();
        int Dice3 = DiceMath.Dice6();

        NumberVal = Dice1 + Dice2 + Dice3;
        NumberVal *= 5;

        print(Dice1 + "  " + Dice2 + "  " + Dice3 );
        ViewText.text = NumberVal.ToString();
    }
}
