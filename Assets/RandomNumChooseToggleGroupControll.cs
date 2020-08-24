using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomNumChooseToggleGroupControll : SingletonMonoBehavior<RandomNumChooseToggleGroupControll>
{
    [SerializeField]
    RandomToggleControll[] togglesControll;
    public void ChangeName()
    {
        for (int i = 0; i < togglesControll.Length; i++)
        {
            togglesControll[i].UpdateName();
        }
    }

    public void CaneclSelection()
    {
        for (int i = 0; i < togglesControll.Length; i++)
        {
            togglesControll[i].GetComponent<Toggle>().isOn = false;
        }
    }
}
