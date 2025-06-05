using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; private set; }

    [SerializeField] private List<Item> allItems = new List<Item>();
    private Dictionary<string, Item> lookup = new Dictionary<string, Item>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            lookup.Clear();
            foreach (var item in allItems)
            {
                if (item == null)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(item.itemId) && !lookup.ContainsKey(item.itemId))
                {
                    lookup.Add(item.itemId, item);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Item GetItemById(string itemId)
    {
        if (lookup.TryGetValue(itemId, out var item))
            return item;
        return null;
    }
}
