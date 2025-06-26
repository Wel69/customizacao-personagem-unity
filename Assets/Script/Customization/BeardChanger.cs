using UnityEngine;

public class BeardChanger : MonoBehaviour
{
    public GameObject[] beardModels; // Lista de Barba diferentes
    private int currentBeardIndex = 0;

    public void SetBeardByIndex(int index)
    {
        if (index < 0 || index >= beardModels.Length) return;

        // Desativa todos os cabelos
        foreach (GameObject beard in beardModels)
            beard.SetActive(false);

        // Ativa o cabelo selecionado
        beardModels[index].SetActive(true);
        currentBeardIndex = index;
    }

    public int GetCurrentBeardIndex()
    {
        return currentBeardIndex;
    }

    public GameObject GetCurrentBeardModel()
    {
        return beardModels[currentBeardIndex];
    }


public void SetHairByIndex(int index)
{
    Debug.Log($"Aplicando cabelo: {index}");
    // resto do código...
}


}
