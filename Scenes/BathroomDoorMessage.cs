using UnityEngine;
using TMPro; // For TextMeshPro
// OR you can use: using UnityEngine.UI; // For regular UI Text

public class BathroomDoorMessage : MonoBehaviour
{
    // Public reference to the text component
    public TextMeshProUGUI messageText; // For TextMeshPro
                                        // OR use: public Text messageText; // For regular UI Text
    public AudioClip keySound;
    // How long to display the message (in seconds)
    public float displayTime = 8.0f;

    void Start()
    {
        // Optional: Clear any text at start
        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(keySound, transform.position);
        // Use the referenced text component
        if (messageText != null)
        {
            // Set the message
            messageText.text = "Someone's in Here!!";

            // Create a TextClearer object that will survive after this object is destroyed
            GameObject textClearer = new GameObject("TextClearer");
            TextClearer clearer = textClearer.AddComponent<TextClearer>();
            clearer.SetupClearText(messageText, displayTime);
        }
        else
        {
            Debug.LogWarning("Message Text component is not assigned!");
        }

        Destroy(gameObject);
    }
}


