using UnityEngine;

public class HairColorChanger : MonoBehaviour
{
    public HairChanger hairChanger;
    public Material[] hairColors;

    private int currentHairColorIndex = 0;

    public void SetHairColor(int colorIndex)
    {
        if (colorIndex < 0 || colorIndex >= hairColors.Length)
            return;

        GameObject currentHair = hairChanger.GetCurrentHairModel();
        if (currentHair == null) return;

        MeshRenderer renderer = currentHair.GetComponent<MeshRenderer>();
        if (renderer == null)
        {
            Debug.LogWarning("MeshRenderer não encontrado no modelo de cabelo.");
            return;
        }

        var mats = renderer.materials;
        mats[0] = hairColors[colorIndex]; // muda o slot certo se precisar
        renderer.materials = mats;

        currentHairColorIndex = colorIndex;

    }
        public int GetCurrentHairColorIndex()
    {
        return currentHairColorIndex;
    }

    

    


}

