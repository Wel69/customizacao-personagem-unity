using UnityEngine;

public class CharacterGenderSelector : MonoBehaviour
{
    public GameObject maleModel;
    public GameObject femaleModel;

    public void SelectMale()
    {
        maleModel.SetActive(true);
        femaleModel.SetActive(false);
    }

    public void SelectFemale()
    {
        // Você pode deixar um aviso por enquanto
        Debug.Log("Modelo feminino ainda não está disponível.");
        // Opcional: mostrar uma mensagem na UI
    }
}
