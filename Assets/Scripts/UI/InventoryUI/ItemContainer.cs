using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public UIItem activeItem;
    public GameObject containerOrigin;

    public ItemType[] allowedTypes;

    public void BindItem(UIItem item)
    {
        foreach (var type in allowedTypes)
        {
            if (type == item.item.Type)
            {
                activeItem = item;
                activeItem.gameObject.transform.SetPositionAndRotation(containerOrigin.transform.position, containerOrigin.transform.rotation);
            }
        }
    }

    public void UnbindItem()
    {
        activeItem = null;
    }
}
