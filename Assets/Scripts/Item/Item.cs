using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [Header("Item Data")]
    public string Name;
    public ItemType Type;
    public Sprite Sprite;

    [Header("Item Stats")]
    public int attack;
    public int defense;
    public int speed;
    public int health;
    public int intelect;
    public int vitality;
}
