using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        SaveData data = GameManager.Instance.LoadGame();
        if (data == null)
        {
            Debug.LogWarning("Nenhum dado salvo encontrado.");
            return;
        }


        // Se existir um objeto com tag "PlayerOriginal", pega a posição e rota
        GameObject placeholder = GameObject.FindWithTag("PlayerOriginal");
        Vector3 spawnPos = Vector3.zero;
        Quaternion spawnRot = Quaternion.identity;
         if (placeholder)
    {
        spawnPos = placeholder.transform.position;
        spawnRot = placeholder.transform.rotation;
        Destroy(placeholder); // remove o boneco falso
    }


        // Instancia o personagem carregado na posição correta
         GameObject player = Instantiate(playerPrefab, spawnPos, spawnRot);


       // GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        
        // Aplica as personalizações
        HairChanger hair = player.GetComponentInChildren<HairChanger>();
        BeardChanger beard = player.GetComponentInChildren<BeardChanger>();
        HairColorChanger hairColor = player.GetComponentInChildren<HairColorChanger>();
        BeardColorChanger beardColor = player.GetComponentInChildren<BeardColorChanger>();

        if (hair != null) hair.SetHairByIndex(data.hairIndex);
        if (beard != null) beard.SetBeardByIndex(data.beardIndex);
        if (hairColor != null) hairColor.SetHairColor(data.hairColorIndex); // verifique o nome correto
        if (beardColor != null) beardColor.SetBeardColor(data.beardColorIndex); // idem


        Debug.Log("Personagem carregado e instanciado na posição correta!");
    }
}
