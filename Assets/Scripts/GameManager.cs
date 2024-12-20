using TMPro;
using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
     // Reference to the TextMeshPro component
    public TextMeshPro counterText;

    private int pickupCount = 0; // Counter for pickups

    private void Awake()
    {
        // Ensure there's only one GameManager instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPickup()
    {
        pickupCount++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = "Cookies: " + pickupCount;
        }
    }
}
