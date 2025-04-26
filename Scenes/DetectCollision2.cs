using UnityEngine;
using UnityEngine.UI; // For UI components

public class DetectCollision2 : MonoBehaviour
{
    // Reference to the door you want to destroy
    public GameObject doorToDestroy;

    void Start()
    {
        // If not assigned in inspector, try to find it by name
        if (doorToDestroy == null)
        {
            doorToDestroy = GameObject.Find("DoorDoubleB");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the door
        if (doorToDestroy != null)
        {
            Destroy(doorToDestroy);
        }
        else
        {
            Debug.LogWarning("Door object not found or not assigned!");
        }

        // Destroy this game object (the key)
        Destroy(gameObject);
    }
}
