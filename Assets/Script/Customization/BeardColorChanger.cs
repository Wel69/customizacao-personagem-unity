using UnityEngine;

public class BeardColorChanger : MonoBehaviour
{
    public BeardChanger beardChanger;
    public Material[] beardColors;

    private int currentBeardColorIndex = 0;

    public void SetBeardColor(int colorIndex)
    {
        if (colorIndex < 0 || colorIndex >= beardColors.Length)
            return;

        GameObject currentBeard = beardChanger.GetCurrentBeardModel();
        if (currentBeard == null) return;

        MeshRenderer renderer = currentBeard.GetComponent<MeshRenderer>();
        if (renderer == null)
        {
            Debug.LogWarning("MeshRenderer não encontrado no modelo de Barba.");
            return;
        }

        var mats = renderer.materials;
        mats[0] = beardColors[colorIndex]; // muda o slot certo se precisar
        renderer.materials = mats;
        
        currentBeardColorIndex = colorIndex;
    }

    
    public int GetCurrentBeardColorIndex()
    {
        return currentBeardColorIndex;
    }


}
