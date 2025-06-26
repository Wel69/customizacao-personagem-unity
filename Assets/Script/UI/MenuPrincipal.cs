using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelMenu;
    public GameObject painelOpcoes;
    public GameObject painelPressStart;

    public SceneLoaderWithFade sceneLoader;
    public int Num;


     void Start()
{
    if (painelPressStart == null || painelMenu == null)
    {
        Debug.LogError("Um dos painéis não foi atribuído no inspetor!");
        return;
    }

    painelPressStart.SetActive(true);
    painelMenu.SetActive(false);
}


    public void AtivarMenuPrincipal()
    {
        painelPressStart.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void NovoJogo()
    {
       // PlayerPrefs.DeleteAll(); // Limpa saves antigos (opcional)
    
        SceneManager.LoadScene(3); // Substitua pelo índice ou nome da sua primeira cena jogável
    }

    public void Continuar()
    {
        // Aqui vai o sistema de save futuramente
        Debug.Log("Continuar ainda não implementado.");
    }

    public void AbrirOpcoes()
    {
        painelMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void SairDoJogo()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
