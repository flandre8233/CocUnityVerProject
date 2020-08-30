using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PropertyValBox : MonoBehaviour 
{
    public PropertyBoxControll propertyBoxControll;
    public void OnDrop(GameObject DataObj)
    {
        if (DataObj != null)
        {
            DataObj.GetComponent<RectTransform>().parent = transform;
            DataObj.GetComponent<RectTransform>().anchoredPosition =  new Vector2();
            propertyBoxControll.OnValueChanged(DataObj.GetComponent<ValControll>().NumberVal);
        }
    }

 
}
