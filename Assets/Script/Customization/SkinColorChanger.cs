using UnityEngine;

public class SkinColorChanger : MonoBehaviour
{
    public SkinnedMeshRenderer bodyRenderer; // ← trocou aqui!
    public Material[] skinMaterials;

    public void SetSkinColor(int index)
    {
        if (index < 0 || index >= skinMaterials.Length)
        {
            Debug.LogWarning("Índice de material de pele inválido!");
            return;
        }

        var mats = bodyRenderer.materials;
        mats[0] = skinMaterials[index]; // ou outro índice, depende da ordem no modelo
        bodyRenderer.materials = mats;
    }
}
