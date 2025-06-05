using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SignUpManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_InputField passwordCorrectInput;
    [SerializeField] private TextMeshProUGUI ErrorMessege;

    private string savePath = "C:\\Users\\wh955\\OneDrive\\Desktop\\SpartanMetaverse\\SprataATM\\Assets\\Data\\users.json";
    private List<UserData> userList = new List<UserData>();

    private void Awake()
    {
        LoadUserList();
    }

    public void OnSignUp()
    {
        string userName = nameInput.text;
        string id = idInput.text;
        string pw = passwordInput.text;
        string pwc = passwordCorrectInput.text;

        bool isDuplicate = userList.Exists(user => user.ID == id);

        if (string.IsNullOrEmpty(userName))
        {
            ErrorMessege.text = "이름이 비었습니다.";
            UIManager.Instance.OnPopup2();
            return;
        }
        if (string.IsNullOrEmpty(id))
        {
            ErrorMessege.text = "id가 비었습니다.";
            UIManager.Instance.OnPopup2();
            return;
        }
        if (string.IsNullOrEmpty(pw))
        {
            ErrorMessege.text = "pw가 비었습니다.";
            UIManager.Instance.OnPopup2();
            return;
        }
        if (pw != pwc)
        {
            ErrorMessege.text = "pw와 pwc가 다릅니다.";
            UIManager.Instance.OnPopup2();
            return;
        }
        if (isDuplicate)
        {
            ErrorMessege.text = "중복된 id입니다.";
            UIManager.Instance.OnPopup2();
            return;
        }
        var newUser = new UserData(userName, id, pw);
        userList.Add(newUser);
        SaveUserList();

        Debug.Log("회원가입 완료.");
        UIManager.Instance.OnSignUpExit();
    }
    public void OnCancle()
    {
        nameInput.text = "";
        idInput.text = "";
        passwordInput.text = "";
        passwordCorrectInput.text = "";
        UIManager.Instance.OnSignUpExit();
    }
    private void LoadUserList()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userList = JsonUtilityWrapper.FromJsonList<UserData>(json);
        }
    }

    private void SaveUserList()
    {
        string json = JsonUtilityWrapper.ToJsonList(userList, true);
        File.WriteAllText(savePath, json);
    }
}
