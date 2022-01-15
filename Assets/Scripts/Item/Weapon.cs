using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", fileName = "Weapon")]
public class Weapon : Item
{
    [Header("Weapon Data")]
    public GameObject Prefab;
    public int MaxXP;
    public Weapon Upgrade;
}
