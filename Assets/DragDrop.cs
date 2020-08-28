using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;

    PropertyValBox propertyBoxVal;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = CharCreateCanvasControll.instance.GetComponent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        rectTransform.parent = canvas.transform;

        if (propertyBoxVal != null)
        {
            propertyBoxVal.propertyBoxControll.OnValueChanged(0);
            propertyBoxVal = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<PropertyValBox>())
        {
            propertyBoxVal = eventData.pointerEnter.GetComponent<PropertyValBox>();
        }
        else
        {
   
            ResetPos();
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void ResetPos()
    {
        GetComponent<RectTransform>().parent = GetComponent<ValControll>().motherBase.transform;
        GetComponent<RectTransform>().anchoredPosition = new Vector2();
    }
}
