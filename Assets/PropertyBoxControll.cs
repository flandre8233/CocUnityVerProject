using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropertyBoxControll : MonoBehaviour
{
    [SerializeField] PropertyValBox propertyValBox;
    [SerializeField] Text ViewText;

    public int value;

    public void UpdateText(string text)
    {
        ViewText.text = text;
    }

    public void OnValueChanged(int Value)
    {
        value = Value;
        print("OnValueChanged ! : " + value);
    }
}
