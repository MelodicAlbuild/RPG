using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> items;
    public GameObject genericItem;

    public List<GameObject> inventoryContainers;

    public GameObject itemParent;

    public void GenerateItem()
    {
        bool placed = false;
        foreach (GameObject container in inventoryContainers)
        {
            if (!placed)
            {
                ItemContainer itemContainer = container.GetComponent<ItemContainer>();
                if (itemContainer.activeItem == null)
                {
                    int itemKey = Random.Range(0, items.Count);
                    GameObject newItem = Instantiate(genericItem, itemParent.transform);
                    newItem.GetComponent<UIItem>().item = items[itemKey];
                    itemContainer.activeItem = newItem.GetComponent<UIItem>();
                    itemContainer.BindItem(newItem.GetComponent<UIItem>());
                    placed = true;
                }
            }
        }
    }
}
