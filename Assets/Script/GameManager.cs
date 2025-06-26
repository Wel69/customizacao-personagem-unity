using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{  
     public int hairIndex;
    public int beardIndex;
    public int hairColorIndex;
    public int beardColorIndex;
    public string characterName;
    // campos
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string saveFilePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Caminho para o arquivo save
            saveFilePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true); // true = formatado (indentado)
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Jogo salvo em: " + saveFilePath);
        Debug.Log("Dados salvos: " + data.characterName);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Jogo carregado!");
            return data;
        }
        else
        {
            Debug.LogWarning("Nenhum arquivo de save encontrado.");
            return null;
        }
    }
}
