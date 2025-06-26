using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButtonRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool rotateRight = true;
    public CharacterRotationController rotationController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (rotateRight)
            rotationController.StartRotateRight();
        else
            rotationController.StartRotateLeft();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rotationController.StopRotation();
    }
}
