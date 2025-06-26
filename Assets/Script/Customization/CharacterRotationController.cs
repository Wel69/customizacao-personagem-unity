using UnityEngine;

public class CharacterRotationController : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private int rotationDirection = 0;

    void Update()
    {
        if (rotationDirection != 0)
        {
            transform.Rotate(Vector3.up, rotationSpeed * rotationDirection * Time.deltaTime);
        }
    }

    public void StartRotateLeft()
    {
        rotationDirection = -1;
    }

    public void StartRotateRight()
    {
        rotationDirection = 1;
    }

    public void StopRotation()
    {
        rotationDirection = 0;
    }
}
