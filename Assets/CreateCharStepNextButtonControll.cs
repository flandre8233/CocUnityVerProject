using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateCharStepNextButtonControll : MonoBehaviour
{
    [SerializeField]
    Text ResultText;

   public void ResultListener()
    {
        if (CharCreateControll.instance.StepCounter >= 4)
        {
            ResultText.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
