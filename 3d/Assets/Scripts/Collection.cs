using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;

    public float  CollectionDelay;
   private void OnTriggerEnter(Collider other)
{
     PlayerManager playermanager = other.GetComponent<PlayerManager>();


     if(playermanager != null)
     {
         playermanager.WoodCollected();
         source.PlayOneShot(clip);
         Destroy(gameObject, CollectionDelay);            
     }
}

}
