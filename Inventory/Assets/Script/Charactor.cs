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

    private Dictionary<EquipmentSlot, Item> equippedItems;
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
        equippedItems = new Dictionary<EquipmentSlot, Item>();
    }
    public void ToggleEquip(Item item, GameObject equipIcon)
    {
        if (item == null || !item.equipable)
            return;
        if (item.isEquipped)
        {
            Unequip(item);
        }
        else
        {
            if (equippedItems.TryGetValue(item.slot, out var existing))
            {
                Unequip(existing);
            }
            Equip(item);
        }

        var allSlots = UnityEngine.Object.FindObjectsOfType<UISlot>();

        foreach (var slot in allSlots)
        {
            if (slot.currentItem != null)
            {
                slot.equipIcon.SetActive(slot.currentItem.isEquipped);
            }
        }
    }
    private void Equip(Item item)
    {
        Debug.Log("장착!");
        item.isEquipped = true;
        equippedItems[item.slot] = item;

        att += item.attBonus;
        def += item.defBonus;
        hp += item.hpBonus;
        crit += item.critBonus;
    }

    private void Unequip(Item item)
    {
        Debug.Log("장착해제!");
        item.isEquipped = false;
        if (equippedItems.ContainsKey(item.slot))
            equippedItems.Remove(item.slot);
        att -= item.attBonus;
        def -= item.defBonus;
        hp -= item.hpBonus;
        crit -= item.critBonus;
    }
}
