using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TextMeshProUGUI ErrorMessage;

    private List<UserData> userList = new List<UserData>();
    private string savePath;

    private void Awake()
    {
        savePath = "C:\\Users\\wh955\\OneDrive\\Desktop\\SpartanMetaverse\\SprataATM\\Assets\\Data\\users.json";
    }

    public void OnLogin()
    {
        LoadUserList();
        string id = idInput.text;
        string pw = passwordInput.text;

        UserData matchedUser = userList.Find(u => u.ID == id && u.Password == pw);

        if (matchedUser != null)
        {
            GameManager.Instance.userData = matchedUser;
            GameManager.Instance.SetUserDataFromLogin();
            UIManager.Instance.OnLoginSuccess();
        }
        else
        {
            ErrorMessage.text = "ID 또는 비밀번호가 틀렸습니다.";
            UIManager.Instance.OnPopup2();
        }
    }

    private void LoadUserList()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userList = JsonUtilityWrapper.FromJsonList<UserData>(json);
        }
        else
        {
            userList = new List<UserData>();
        }
    }
}
