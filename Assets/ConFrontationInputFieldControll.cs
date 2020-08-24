using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConFrontationInputFieldControll : MonoBehaviour
{
    [SerializeField]
    InputField[] inputFields;

   

    public void CheckInputField()
    {
        bool Result = false;

        foreach (var item in inputFields)
        {
            if(item.text == "")
            {
                Result = true;
                break;
            }
        }

        ConFrontationControll.instance.RandomButton.interactable = !Result;
    }


}
