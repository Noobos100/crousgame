using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    public int playerHealth = 100; // Player's health
    public int damageAmount = 10; // Damage amount
    public AudioSource m_damageSound; // Damage sound
    public AudioSource m_deathSound; // Death sound

    public Animator animator; // Reference to the Animator
    private KeyMove movementScript; // Reference to the KeyMove script
    public HealthBar healthBar; // Reference to the HealthBar script

    void Start()
    {
        // Set the player's health to 100
        playerHealth = 100;
        healthBar.SetMaxHealth(playerHealth);

        // Ensure the animator is assigned (optional safety check)
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        movementScript = GetComponent<KeyMove>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with an object tagged "Enemy"
        if (collision.gameObject.tag == "Enemy")
        {
            // Reduce the player's health by the damage amount
            playerHealth -= damageAmount;
            healthBar.SetHealth(playerHealth);
            m_damageSound.Play();

            // Check if the player's health is less than or equal to 0
            if (playerHealth <= 0)
            {
                // Player is dead
                playerDeath();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered a "KillZone"
        if (other.gameObject.tag == "KillZone")
        {
            // Player is dead
            playerHealth = 0;
            healthBar.SetMaxHealth(playerHealth);
            Debug.Log("Player is dead!");
            playerDeath();
        }
    }

    void playerDeath()
    {
        m_deathSound.Play();


        // Disable movement
        if (movementScript != null)
        {
            movementScript.DisableMovement();
        }

        // Set the Animator's isDead parameter
        animator.SetBool("isDead", true);

        // Wait for 3 seconds then load the GameOver scene
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Load the GameOver scene
        SceneManager.LoadScene("GameOver");
    }
}