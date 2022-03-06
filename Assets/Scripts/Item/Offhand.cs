using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Offhand", fileName = "Offhand")]
public class Offhand : Item
{
    [Header("Offhand Data")]
    public GameObject Prefab;
    public int MaxXP;
    public Offhand Upgrade;
}
