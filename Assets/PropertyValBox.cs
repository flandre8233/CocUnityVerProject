using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PropertyValBox : MonoBehaviour , IDropHandler
{
    public PropertyBoxControll propertyBoxControll;
    public void OnDrop(PointerEventData eventData)
    {
        if (propertyBoxControll.value <= 0 && eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().parent = transform;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =  new Vector2();
            propertyBoxControll.OnValueChanged(eventData.pointerDrag.GetComponent<ValControll>().NumberVal);
        }
    }

 
}
