using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Progress;

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
    public void InitInventoryUI(Charactor character)
    {
        if (character == null) return;
        for (int i = slots.Count; i < character.inventory.Count; i++)
        {
            var item = character.inventory[i];
            var slotGO = Instantiate(slotPrefab.gameObject, slotParent);
            var uiSlot = slotGO.GetComponent<UISlot>();

            uiSlot.Initialize(item, character);
            slots.Add(uiSlot);
        }
    }
    public void OnInventoryExit()
    {
        UIManager.Instance.SetInven(false);
        UIManager.Instance.SetMain(true);
    }
}
