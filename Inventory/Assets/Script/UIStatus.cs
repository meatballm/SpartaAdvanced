using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public static UIStatus instance;
    [SerializeField] private TextMeshProUGUI Att;
    [SerializeField] private TextMeshProUGUI Def;
    [SerializeField] private TextMeshProUGUI Hp;
    [SerializeField] private TextMeshProUGUI Crit;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetStatusUI();
    }
    public void SetStatusUI()
    {
        Att.text = string.Format("{0:N0}", GameManager.Instance.player.att);
        Def.text = string.Format("{0:N0}", GameManager.Instance.player.def);
        Hp.text = string.Format("{0:N0}", GameManager.Instance.player.hp);
        Crit.text = string.Format("{0:N0}", GameManager.Instance.player.crit);
    }
    public void OnStatusExit()
    {
        UIManager.Instance.SetStatus(false);
        UIManager.Instance.SetMain(true);
    }
}
