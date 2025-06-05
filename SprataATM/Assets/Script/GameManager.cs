using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private string savePath;
    public UserData userData;

    [Header("임시 UI 연동용")]
    public string Name;
    public string BalanceString;
    public string CashString;

    public decimal Balance
    {
        get => decimal.TryParse(BalanceString, out var result) ? result : 0;
        set => BalanceString = value.ToString();
    }

    public decimal Cash
    {
        get => decimal.TryParse(CashString, out var result) ? result : 0;
        set => CashString = value.ToString();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        savePath = "C:\\Users\\wh955\\OneDrive\\Desktop\\SpartanMetaverse\\SprataATM\\Assets\\Data\\users.json";
    }

    private void Start()
    {
        if (userData != null)
        {
            Name = userData.UserName;
            Balance = userData.AccountMoney;
            Cash = userData.Cash;
        }
    }

    public void UpdateAccount()
    {
        userData.UserName = Name;
        userData.AccountMoney = Balance;
        userData.Cash = Cash;

        SaveUserData();
    }

    public void SaveUserData()
    {
        if (userData == null)
        {
            Debug.LogWarning("[GameManager] userData가 null이라 저장할 수 없습니다.");
            return;
        }

        if (File.Exists(savePath))
        {
            string jsonAll = File.ReadAllText(savePath);
            List<UserData> allUsers = JsonUtilityWrapper.FromJsonList<UserData>(jsonAll);

            for (int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers[i].ID == userData.ID)
                {
                    allUsers[i] = userData;
                    break;
                }
            }
            string newJson = JsonUtilityWrapper.ToJsonList(allUsers, true);
            File.WriteAllText(savePath, newJson);
        }
        else
        {
            Debug.LogWarning("저장 파일이 존재하지 않아 저장하지 못했습니다.");
        }
    }

    public void SetUserDataFromLogin()
    {
        if (userData != null)
        {
            Name = userData.UserName;
            Balance = userData.AccountMoney;
            Cash = userData.Cash;

            Debug.Log($"[GameManager] 로그인 유저 정보 설정 완료: {Name}, Cash: {Cash}, Balance: {Balance}");
        }
        else
        {
            Debug.LogWarning("[GameManager] userData가 null입니다.");
        }
    }
}
