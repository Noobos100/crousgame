using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageEnemy : MonoBehaviour
{
    public int enemyHealth = 100; // enemy's health
    public int damageAmount = 100; // Damage amount
    public AudioSource m_damageSound; // Damage sound
    
    void Start()
    {

    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Swat" && FindObjectOfType<Attack>().m_isAttacking){
            // Play the damage sound
            m_damageSound.Play();

            Debug.Log("enemy is dead!");

            // flip enemy over
            transform.Rotate(90, 0, 0);

            // Destroy the enemy
            Destroy(gameObject, 1f);
        }
    }

}