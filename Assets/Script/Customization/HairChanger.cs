using UnityEngine;

public class HairChanger : MonoBehaviour
{
    public GameObject[] hairModels; // Lista de cabelos diferentes
    private int currentHairIndex = 0;

    public void SetHairByIndex(int index)
    {
        if (index < 0 || index >= hairModels.Length) return;

        // Desativa todos os cabelos
        foreach (GameObject hair in hairModels)
            hair.SetActive(false);

        // Ativa o cabelo selecionado
        hairModels[index].SetActive(true);
        currentHairIndex = index;
    }

    public int GetCurrentHairIndex()
    {
        return currentHairIndex;
    }

    public GameObject GetCurrentHairModel()
    {
        return hairModels[currentHairIndex];
    }

    
}
