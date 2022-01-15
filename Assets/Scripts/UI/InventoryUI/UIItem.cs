using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    private Sprite itemSprite;

    public Slider xpSlider;
    public Button xpButton;

    [Header("Weapon Specific")]
    public int CurrentXP;

    private void Awake()
    {
        if (item != null)
        {
            itemSprite = item.Sprite;
            if (item.Type == ItemType.Weapon)
            {
                xpSlider.enabled = true;
                xpButton.enabled = true;
                xpSlider.gameObject.SetActive(true);
                xpButton.gameObject.SetActive(true);
            }
        }
        else
        {
            itemSprite = null;
        }
    }

    private void Update()
    {
        if (item != null)
        {
            itemSprite = item.Sprite;
            GetComponent<Image>().sprite = itemSprite;

            if (item.Type == ItemType.Weapon)
            {
                xpSlider.value = CurrentXP / 100.0f;

                if (CurrentXP == (item as Weapon).MaxXP)
                {
                    if ((item as Weapon).Upgrade != null)
                    {
                        item = (item as Weapon).Upgrade;
                        CurrentXP = 0;
                        xpSlider.value = 0;
                    }
                }
            }
        }
    }

    public void UpdateItem(Item item)
    {
        if (this.item != null)
        {
            itemSprite = this.item.Sprite;
        }
        else
        {
            itemSprite = null;
        }
    }

    public void AddXP(int amount)
    {
        if (item.Type == ItemType.Weapon)
        {
            if (CurrentXP < (item as Weapon).MaxXP)
            {
                CurrentXP += amount;
            }
            else
            {
                CurrentXP = (item as Weapon).MaxXP;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (transform != null)
        {
            GetComponent<FollowMousePosition>().Disable();
            ItemContainer container = GetClosestContainer(FindObjectsOfType<ItemContainer>());
            container.BindItem(this);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<FollowMousePosition>().Enable();
        ItemContainer container = GetClosestContainer(FindObjectsOfType<ItemContainer>());
        container.UnbindItem();
    }

    ItemContainer GetClosestContainer(ItemContainer[] containers)
    {
        ItemContainer tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (ItemContainer container in containers)
        {
            float dist = Vector3.Distance(container.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = container;
                minDist = dist;
            }
        }
        return tMin;
    }
}
