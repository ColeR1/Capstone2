using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float healCoolDown; //Cooldown so the player doesnt heal to 100 instantly;
    public int healAmount; // how much the player will heal each tick;

    private PlayerHealthController playerHealth; //Reference to the players health;
    private float lastheal; //Time since the last heal occured

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

            //Check if enough time has passed since last attack
            if(Time.time - lastheal >= healCoolDown)
            {
                HealPlayer();
                healCoolDown = Time.time; //Updaet the last attack time
            }
        }
    }

    private void HealPlayer()
    {
        if(playerHealth != null)
        {
            playerHealth.Heal(healAmount); //How much the player heals
        }
    }


}
