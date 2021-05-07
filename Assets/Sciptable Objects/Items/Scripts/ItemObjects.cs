using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType //set ItemTypes
{
    Food,
    Equiptment,
    Default
}
public enum Attributes { //set attributes for ItemBuff class
    Agility,
    Intellect,
    Stamina,
    Strength
}
public abstract class ItemObjects : ScriptableObject //ItemObjects abstract class
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public ItemBuff[] buffs;

    public Item CreateItem() //to create new items
    {
        Item newItem = new Item(this);
        return newItem;
    }
}
[System.Serializable]
public class Item //Item class to hold data
{
    public string Name;
    public int Id;
    public ItemBuff[] buffs;
    public Item(ItemObjects item)
    {
        Name = item.name;
        Id = item.Id;
        buffs = new ItemBuff[item.buffs.Length];
        for(int i = 0; i < buffs.Length; i++){
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max); //wait on random value generation
            {
            buffs[i].attribute = item.buffs[i].attribute;
            }
        }
    }
}
[System.Serializable]
public class ItemBuff //itembuff class creation
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max) //item buff min/max
    {
        min = _min;
        max = _max;

    }
    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min,max);
    }
}