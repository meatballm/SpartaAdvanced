using System;
using UnityEngine;
public enum EquipmentSlot
{
    Head,
    Body,
    Weapon,
    Accessory
}
[System.Serializable]
public class Item
{
    public string itemId;
    public Sprite icon;
    public bool equipable;
    public EquipmentSlot slot;
    public int attBonus;
    public int defBonus;
    public int hpBonus;
    public int critBonus;
    public Item(string itemId, Sprite icon, bool equipable, EquipmentSlot slot,int attBonus, int defBonus, int hpBonus, int critBonus)
    {
        this.itemId = itemId;
        this.icon = icon;
        this.equipable = equipable;
        this.slot = slot;
        this.attBonus = attBonus;
        this.defBonus = defBonus;
        this.hpBonus = hpBonus;
        this.critBonus = critBonus;
    }
}
