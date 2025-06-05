using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealMoney : MonoBehaviour
{
    public void MoneyMoved(bool deposit, decimal amount)
    {
        if (deposit)
        {
            if(GameManager.Instance.Cash - amount < 0)
            {
                UIManager.Instance.OnPopup();
                return;
            }
            GameManager.Instance.Balance += amount;
            GameManager.Instance.Cash -= amount;
        }
        else
        {
            if (GameManager.Instance.Balance - amount < 0)
            {
                UIManager.Instance.OnPopup();
                return;
            }
            GameManager.Instance.Balance -= amount;
            GameManager.Instance.Cash += amount;
        }
        GameManager.Instance.UpdateAccount();
        UIManager.Instance.Refresh();
    }
}
