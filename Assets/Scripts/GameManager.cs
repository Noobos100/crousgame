using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public TextMeshProUGUI counterText; // Reference to the pickup counter text
    public TextMeshProUGUI healthText;  // Reference to the health text

    private DamagePlayer damagePlayer;  // Reference to the DamagePlayer script
    private int pickupCount = 0;        // Counter for pickups

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

    private void Start()
    {
        // Find and reference the DamagePlayer script
        damagePlayer = FindObjectOfType<DamagePlayer>();
        UpdateUI();
    }

    private void Update()
    {
        if (damagePlayer != null)
        {
            // Update health text dynamically
            UpdateHealthText(damagePlayer.playerHealth);
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

        if (healthText != null && damagePlayer != null)
        {
            healthText.text = "Health: " + damagePlayer.playerHealth + "%";
        }
    }

    private void UpdateHealthText(int health)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health + "%";
        }
    }
}
