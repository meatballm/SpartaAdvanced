using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Send : MonoBehaviour
{
    [SerializeField] private TMP_InputField targetIdInput;
    [SerializeField] private TMP_InputField amountInput;
    [SerializeField] private TextMeshProUGUI resultText;

    private string savePath;

    private void Awake()
    {
        savePath = SaveManager.instance.savePath;
    }

    public void OnSend()
    {
        string targetId = targetIdInput.text.Trim();
        if (!decimal.TryParse(amountInput.text, out decimal amount) || amount <= 0)
        {
            ShowResult("잘못된 금액입니다.");
            return;
        }

        var sender = GameManager.Instance.userData;
        if (sender == null)
        {
            ShowResult("로그인된 사용자가 없습니다.");
            return;
        }

        if (sender.ID == targetId)
        {
            ShowResult("본인에게는 송금할 수 없습니다.");
            return;
        }

        if (sender.AccountMoney < amount)
        {
            ShowResult("계좌 잔액이 부족합니다.");
            return;
        }

        if (!File.Exists(savePath))
        {
            ShowResult("사용자 데이터 파일이 없습니다.");
            return;
        }

        string json = File.ReadAllText(savePath);
        List<UserData> allUsers = JsonUtilityWrapper.FromJsonList<UserData>(json);

        bool receiverFound = false;

        for (int i = 0; i < allUsers.Count; i++)
        {
            if (allUsers[i].ID == sender.ID)
            {
                allUsers[i].AccountMoney -= amount; // 내 계좌에서 차감
            }
            else if (allUsers[i].ID == targetId)
            {
                allUsers[i].AccountMoney += amount; // 상대 계좌에 추가
                receiverFound = true;
            }
        }

        if (!receiverFound)
        {
            ShowResult("대상 ID를 찾을 수 없습니다.");
            return;
        }

        // 저장
        string newJson = JsonUtilityWrapper.ToJsonList(allUsers, true);
        File.WriteAllText(savePath, newJson);

        // 현재 사용자 메모리 업데이트
        sender.AccountMoney -= amount;
        GameManager.Instance.Balance = sender.AccountMoney;
        GameManager.Instance.UpdateAccount();

        ShowResult($"{targetId}에게 {amount}원 송금 완료");
    }

    private void ShowResult(string message)
    {
        if (resultText != null)
            resultText.text = message;
        UIManager.Instance.OnPopup2();
    }
}
