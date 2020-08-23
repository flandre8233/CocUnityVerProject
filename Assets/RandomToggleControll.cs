using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomToggleControll : MonoBehaviour
{
    [SerializeField] int Nubmer;
    [SerializeField] Button RandomButton;
    public void OnToggle(bool boolean)
    {
        RandomButton.interactable = boolean;
        RandomManager.instance.ActiveRandomNumber = Nubmer;
    }

    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(OnToggle);
    }

    public void UpdateName()
    {
        GetComponentInChildren<Text>().text = RandomManager.instance.RandomTimes + "D" + Nubmer;
    }
}
