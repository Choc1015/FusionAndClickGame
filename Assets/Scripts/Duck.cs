using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Duck : MonoBehaviour, IBeginDragHandler, IDragHandler ,IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
