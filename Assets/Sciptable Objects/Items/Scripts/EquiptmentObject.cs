using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equiptment Object", menuName = "Inventory System/Items/Equiptment")]
public class EquiptmentObject : ItemObjects
{
    public float atkBonus;
    public float defenceBonus;
    public void Awake()
    {
        type = ItemType.Equiptment;
    }
}
