using UnityEngine;
using TMPro; // For TextMeshPro
// OR you can use: using UnityEngine.UI; // For regular UI Text

public class KeyDestroy : MonoBehaviour
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
            messageText.text = "The Door Might Be Open!";

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

// Helper class to clear the text after a delay, even when the original object is gone
public class TextClearer : MonoBehaviour
{
    private TMPro.TextMeshProUGUI textToManage; // For TextMeshPro
                                                // OR use: private UnityEngine.UI.Text textToManage; // For regular UI Text

    private float timeToWait;
    private float timer = 0f;

    public void SetupClearText(TMPro.TextMeshProUGUI text, float time) // For TextMeshPro
    // OR use: public void SetupClearText(UnityEngine.UI.Text text, float time) // For regular UI Text
    {
        textToManage = text;
        timeToWait = time;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToWait)
        {
            if (textToManage != null)
            {
                textToManage.text = "";
            }

            Destroy(gameObject); // Destroy this clearer object once done
        }
    }
}