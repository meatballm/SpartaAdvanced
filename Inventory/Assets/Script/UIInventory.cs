using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;

    private readonly List<UISlot> slots = new List<UISlot>();

    public static UIInventory instance;

    private void Awake()
    {
        instance = this;
    }
    public void InitInventoryUI(List<Item> items)
    {
        foreach (var s in slots)
            Destroy(s.gameObject);
        slots.Clear();

        for (int i = 0; i < items.Count; i++)
        {
            var slotObj = Instantiate(slotPrefab.gameObject, slotParent);
            var uiSlot = slotObj.GetComponent<UISlot>();
            uiSlot.SetItem(items[i]);
            slots.Add(uiSlot);
        }
    }
    public void OnInventoryExit()
    {
        UIManager.Instance.SetInven(false);
        UIManager.Instance.SetMain(true);
    }
}
