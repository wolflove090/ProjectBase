using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [NonSerialized]
    public System.Action OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
     }

    public void OnPointerDown(PointerEventData e)
    {
        this.transform.DOScale(0.9f, 0.1f);
    }

    public void OnPointerUp(PointerEventData e)
    {
        this.transform.DOScale(1f, 0.1f);

        if (OnClick != null)
            OnClick();
    }
}
