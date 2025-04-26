using UnityEngine;
using TMPro; // For TextMeshPro

using UnityEngine.UI; // For UI components

public class KeyDestroy2 : MonoBehaviour
{
    public TextMeshProUGUI messageText; // For TextMeshPro
    // Reference to the door you want to destroy
    public GameObject doorToDestroy;

    public float displayTime = 8.0f;
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
        if (messageText != null)
        {
            // Set the message
            messageText.text = "Get To The Toilet!!!";

            // Create a TextClearer object that will survive after this object is destroyed
            GameObject textClearer = new GameObject("TextClearer");
            TextClearer clearer = textClearer.AddComponent<TextClearer>();
            clearer.SetupClearText(messageText, displayTime);
        }
        else
        {
            Debug.LogWarning("Message Text component is not assigned!");
        }


        // Destroy this game object (the key)
        Destroy(gameObject);
    }
}
