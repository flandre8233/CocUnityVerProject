using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomToggleControll : MonoBehaviour
{
    [SerializeField] int Nubmer;
    public void OnToggle(bool boolean)
    {
        RandomManager.Intance.ActiveRandomNumber = Nubmer;
    }

    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(OnToggle);
    }
}
