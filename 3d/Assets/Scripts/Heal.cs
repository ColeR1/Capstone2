using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
   public float healInterval = 2f;   // Time interval between each healing
    public int healAmount = 1;        // Amount of HP to heal
    public int quantity = 3;          // Initial quantity
    public float cooldownTime = 10f;  // Time in seconds to wait before reactivating

    private float nextHealTime;       // Time to trigger the next healing
    private bool isCoolingDown = false;
    private float cooldownEndTime;


    private PlayerHealthController playerHealth; //Reference to the players health;


    public GameObject player; //reference to the player gameobject;

    public AudioSource source;
    public AudioClip clip;

    

    // Start is called before the first frame update
     private void Start() {
        playerHealth = FindObjectOfType<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
       if (isCoolingDown)
        {
            if (Time.time >= cooldownEndTime)
            {
                // Cooldown is over, reset quantity and reactivate
                quantity = 3; // Set this to your desired original quantity
                isCoolingDown = false;
                gameObject.SetActive(true);
            }
        }
        else
        {
            // Check if it's time to heal the player
            if (Time.time >= nextHealTime && quantity > 0)
            {
                // Call the healing function and reduce quantity
                HealPlayer(healAmount);
                quantity--;

                // Update the next healing time
                nextHealTime = Time.time + healInterval;

                // Check if quantity reaches 0 and start the cooldown
                if (quantity == 0)
                {
                    StartCooldown();
                }
            }
        }
        }
    }

     private void StartCooldown()
    {
        // Set the cooldown end time
        cooldownEndTime = Time.time + cooldownTime;
        isCoolingDown = true;
        gameObject.SetActive(false); // Deactivate the object
    }


    private void HealPlayer(int amount)
    {
        if(playerHealth != null)
        {
            playerHealth.Heal(healAmount); //How much the player heals
        }
    }


}
