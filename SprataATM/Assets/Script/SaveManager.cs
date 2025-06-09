using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public string savePath;
    public static SaveManager instance;

    private void Awake()
    {
        savePath = "Assets\\Data\\userdata.json";
        instance = this;
    }

    public void Save(UserData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(savePath, json);
        Debug.Log("저장 완료: " + savePath);
    }

    public UserData Load()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("저장된 파일이 없습니다.");
            return null;
        }

        string json = File.ReadAllText(savePath);
        UserData data = JsonUtility.FromJson<UserData>(json);
        Debug.Log("로드 완료");
        return data;
    }
}
