
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Withdraw : DealMoney
{
    private decimal amount;
    private Button[] buttons;
    [SerializeField] private TMP_InputField amountInputField;
    [SerializeField] private string targetTag = "AmountBtn";
    [SerializeField] private string inputTag = "InputBtn";
    private void Start()
    {
        // 자식 오브젝트 중 모든 버튼 가져오기
        buttons = GetComponentsInChildren<Button>();

        foreach (Button btn in buttons)
        {
            if (btn.CompareTag(targetTag))
            {
                Button capturedBtn = btn;
                capturedBtn.onClick.AddListener(() => OnWithdraw(capturedBtn));
            }
            if (btn.CompareTag(inputTag))
            {
                btn.onClick.AddListener(() => OnWithdrawInput());
            }
        }
    }
    public void OnWithdraw(Button btn)
    {
        Text text = btn.GetComponentInChildren<Text>();
        if (decimal.TryParse(text.text, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out amount))
        {
            MoneyMoved(false, amount);
            Debug.Log($"입금 : {amount}원");
        }
        else
        {
            Debug.Log("입금 실패!");
        }
    }
    public void OnWithdrawInput()
    {
        string text = amountInputField.text;
        if (decimal.TryParse(text, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out amount))
        {
            MoneyMoved(false, amount);
            Debug.Log($"입금 : {amount}원");
        }
        else
        {
            Debug.Log("입금 실패!");
        }
    }
}
