using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public void OnInventoryExit()
    {
        UIManager.Instance.SetInven(false);
        UIManager.Instance.SetMain(true);
    }
}
