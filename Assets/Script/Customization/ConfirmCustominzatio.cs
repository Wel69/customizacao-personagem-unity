using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmCustominzatio : MonoBehaviour
{

    public HairChanger hairChanger;
    public HairColorChanger hairColorChanger;
    public BeardChanger beardChanger;
    public BeardColorChanger beardColorChanger;
    public TMPro.TMP_InputField nameField;

    public string nextSceneName = "CenaDoJogo";

    public void ConfirmarCustomizacao()
{
    if (hairChanger == null) Debug.LogError("HairChanger está NULL");
    if (beardChanger == null) Debug.LogError("BeardChanger está NULL");
    if (hairColorChanger == null) Debug.LogError("HairColorChanger está NULL");
    if (beardColorChanger == null) Debug.LogError("BeardColorChanger está NULL");
    if (nameField == null) Debug.LogError("NameField está NULL");
    if (GameManager.Instance == null) Debug.LogError("GameManager.Instance está NULL");

    // Só continua se tudo estiver certo
    if (hairChanger == null || beardChanger == null || hairColorChanger == null || beardColorChanger == null || nameField == null || GameManager.Instance == null)
        return;

    SaveData data = new SaveData
    {
        hairIndex = hairChanger.GetCurrentHairIndex(),
        beardIndex = beardChanger.GetCurrentBeardIndex(),
        hairColorIndex = hairColorChanger.GetCurrentHairColorIndex(),
        beardColorIndex = beardColorChanger.GetCurrentBeardColorIndex(),
        characterName = nameField.text
    };

    GameManager.Instance.SaveGame(data);
    SceneManager.LoadScene(nextSceneName);
}

}
