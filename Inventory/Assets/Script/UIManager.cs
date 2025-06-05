using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject uIMainMenu;
    [SerializeField] private GameObject uiStatus;
    [SerializeField] private GameObject uiInventory;

    public GameObject UIMainMenu => uIMainMenu;
    public GameObject UIStatus => uiStatus;
    public GameObject UIInventory => uiInventory;

    private void Awake()
    {
        Instance = this;
        SetMain(true);
        SetInven(false);
        SetStatus(false);
    }

    public void SetMain(bool active)
    {
        UIMainMenu.SetActive(active);
    }
    public void SetStatus(bool active)
    {
        UIStatus.SetActive(active);
    }
    public void SetInven(bool active)
    {
        UIInventory.SetActive(active);
    }

}
