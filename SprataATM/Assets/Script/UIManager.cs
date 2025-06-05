using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    private GameManager instance;
    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI CashTxt;
    public TextMeshProUGUI BalanceTxt;
    public Button DepositBtn;
    public Button WithdrawBtn;
    public Button DepositExitBtn;
    public Button WithdrawExitBtn;
    public GameObject Deposit;
    public GameObject Withdraw;
    public GameObject Mainmenu;
    public GameObject Main;
    public GameObject Popup;
    public GameObject Popup2;
    public GameObject Login;
    public GameObject SignUp;
    public GameObject Send;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        if (GameManager.Instance != null)
            instance = GameManager.Instance;
        else
            Debug.Log("게임매니저가 없습니다.");
    }
    void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        NameTxt.text = instance.Name.ToString();
        CashTxt.text = string.Format("{0:N0}", instance.Cash);
        BalanceTxt.text = string.Format("{0:N0}", instance.Balance);
    }
    public void OnDepositBtnClicked()
    {
        Deposit.SetActive(true);
        Mainmenu.SetActive(false);
    }
    public void OnDepositExitBtnClicked()
    {
        Deposit.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void OnWithdrawBtnClicked()
    {
        Withdraw.SetActive(true);
        Mainmenu.SetActive(false);
    }
    public void OnWithdrawExitBtnClicked()
    {
        Withdraw.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void OnPopup()
    {
        Popup.SetActive(true);
    }
    public void OnPopupExit()
    {
        Popup.SetActive(false);
    }
    public void OnPopup2()
    {
        Popup2.SetActive(true);
    }
    public void OnPopup2Exit()
    {
        Popup2.SetActive(false);
    }
    public void OnSignUp()
    {
        SignUp.SetActive(true);
    }
    public void OnSignUpExit()
    {
        SignUp.SetActive(false);
    }
    public void OnLoginSuccess()
    {
        Login.SetActive(false);
        Main.SetActive(true);
    }
    public void OnSend()
    {
        Send.SetActive(true);
        Mainmenu.SetActive(false);
    }
    public void OnSendExit()
    {
        Send.SetActive(false);
        Mainmenu.SetActive(true);
    }
}
