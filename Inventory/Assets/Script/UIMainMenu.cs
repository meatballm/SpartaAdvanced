using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Id;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Gold;

    private void Start()
    {
        SetMainUI();
    }
    public void SetMainUI()
    {
        Id.text = string.Format("{0:N0}", GameManager.Instance.player.id);
        Level.text = "Lv."+string.Format("{0:N0}", GameManager.Instance.player.level);
        Gold.text = string.Format("{0:N0}", GameManager.Instance.player.gold);
    }
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
