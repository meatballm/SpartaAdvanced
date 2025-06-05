using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatus : MonoBehaviour
{
    public void OnStatusExit()
    {
        UIManager.Instance.SetStatus(false);
        UIManager.Instance.SetMain(true);
    }
}
