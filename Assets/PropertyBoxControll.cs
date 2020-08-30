using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropertyBoxControll : MonoBehaviour
{
    public CharData.CharPropertyEnum Type;

    [SerializeField] PropertyValBox propertyValBox;
    [SerializeField] Text NameViewText;
    [SerializeField] Text ValueViewText;

    public string SpecValueViewText;

    public string value;

    public bool TextDisplayOnly;

    public bool IsHaveValue {
        get {
            return ValueViewText.text != "" && value != "0";
        }
    }

    private void Start()
    {

        if (TextDisplayOnly)
        {
            NameViewText.text = (SpecValueViewText == "") ? Type.ToString() : SpecValueViewText;
            ValueViewText.text = value;
            ValueViewText.gameObject.SetActive(true);
            Destroy(propertyValBox);
            Destroy(this);
            return;
        }
        UpdateText();
    }

    public void UpdateText()
    {
        NameViewText.text = Type.ToString();
    }

    public void OnValueChanged(int Value)
    {
        value = Value.ToString();
        print("OnValueChanged ! : " + value);
        CharCreateControll.instance.charData.UpdatePropertyData(Type, Value);
        CharCreateCanvasControll.instance.NextButton.interactable = CharCreateControll.instance.CheckAllPropertyBoxDone();
    }
}
