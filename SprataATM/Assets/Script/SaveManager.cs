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
}
