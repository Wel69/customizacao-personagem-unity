using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;




public class UIManagerCustomizacao : MonoBehaviour
{
    public GameObject painelBarba;
    public GameObject painelCabelo;

    public void MostrarBarba()
    {
        painelBarba.SetActive(true);
        painelCabelo.SetActive(false);
    }

    public void MostrarCabelo()
    {
        painelBarba.SetActive(false);
        painelCabelo.SetActive(true);
    }

    
[CreateAssetMenu(fileName = "NewBodyPart", menuName = "Character/Body Part")]
public class BodyPart : ScriptableObject
{
    public string partName;
    public Sprite icon;
    public GameObject prefab;
}









}
