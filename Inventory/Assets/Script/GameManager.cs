using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Charactor player {  get; private set; }

    private void Awake()
    {
        Instance = this;
        player = new Charactor("Gigachad",50,50000,990,990,300,100);
        AddItemToInventory("bomb");
        AddItemToInventory("red");
        AddItemToInventory("green");
        AddItemToInventory("blue");
        AddItemToInventory("yellow");
        AddItemToInventory("goblin");
        AddItemToInventory("skull");
        AddItemToInventory("axe");
        AddItemToInventory("golden");
        AddItemToInventory("chest");
    }

    public void AddItemToInventory(string itemId)
    {
        var item = ItemDatabase.Instance.GetItemById(itemId);
        if (item != null)
            player.inventory.Add(item);
        else
            Debug.LogWarning($"ItemDatabase에 '{itemId}'가 없습니다.");
        UIInventory.instance.InitInventoryUI(player);
    }
}
