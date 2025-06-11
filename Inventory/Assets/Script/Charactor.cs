using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor
{
    public string id { get; private set; }
    public int level { get; private set; }
    public int gold { get; private set; }
    public int att { get; private set; }
    public int def { get; private set; }
    public int hp { get; private set; }
    public int crit { get; private set; }
    public List<Item> inventory { get; private set; }

    private Dictionary<EquipmentSlot, UISlot> equippedItems = new Dictionary<EquipmentSlot, UISlot>();
    public Charactor(string id, int level, int gold, int att, int def, int hp, int crit)
    {
        this.id = id;
        this.level = level;
        this.gold = gold;
        this.att = att;
        this.def = def;
        this.hp = hp;
        this.crit = crit;
        inventory = new List<Item>();
    }
    public void ToggleEquip(UISlot slot)
    {
        if (slot.currentItem == null || !slot.currentItem.equipable)
            return;
        if (slot.isEquipped)
        {
            Unequip(slot);
        }
        else
        {
            if (equippedItems.TryGetValue(slot.currentItem.slot, out var existing))
            {
                Unequip(existing);
                existing.RefreshUI();
            }
            Equip(slot);
        }
    }
    private void Equip(UISlot slot)
    {
        Debug.Log("장착!");
        slot.isEquipped = true;
        equippedItems[slot.currentItem.slot] = slot;

        att += slot.currentItem.attBonus;
        def += slot.currentItem.defBonus;
        hp += slot.currentItem.hpBonus;
        crit += slot.currentItem.critBonus;
    }

    private void Unequip(UISlot slot)
    {
        Debug.Log("장착해제!");
        slot.isEquipped = false;
        if (equippedItems.ContainsKey(slot.currentItem.slot))
            equippedItems.Remove(slot.currentItem.slot);
        att -= slot.currentItem.attBonus;
        def -= slot.currentItem.defBonus;
        hp -= slot.currentItem.hpBonus;
        crit -= slot.currentItem.critBonus;
    }
}
