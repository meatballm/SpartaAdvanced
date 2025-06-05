using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public void OnStatus()
    {
        UIManager.Instance.SetMain(false);
        UIManager.Instance.SetStatus(true);
    }
    public void OnInventory()
    {
        UIManager.Instance.SetMain(false);
        UIManager.Instance.SetInven(true);
    }
}
