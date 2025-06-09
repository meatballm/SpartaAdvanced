using System;
using UnityEngine;

[Serializable]
public class UserData
{
    public string UserName;
    public string ID;
    public string Password;

    [SerializeField] public string cashString;
    [SerializeField] public string accountMoneyString;

    public decimal Cash
    {
        get => decimal.TryParse(cashString, out var val) ? val : 0;
        set => cashString = value.ToString();
    }

    public decimal AccountMoney
    {
        get => decimal.TryParse(accountMoneyString, out var val) ? val : 0;
        set => accountMoneyString = value.ToString();
    }

    public UserData(string name, string id, string password, decimal cash=100000, decimal account=0)
    {
        UserName = name;
        Cash = cash;
        AccountMoney = account;
        ID = id;
        Password = password;
    }
}
