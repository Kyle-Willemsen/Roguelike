using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopUIEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 originalSize;
    public Vector3 hoveredSize;

    private void Start()
    {
        originalSize = gameObject.transform.localScale;
        hoveredSize = new Vector3(originalSize.x + .2f, originalSize.y + .2f, originalSize.z + .2f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hoveredSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalSize;
    }
}
