using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
{
     PlayerManager playermanager = other.GetComponent<PlayerManager>();


     if(playermanager != null)
     {
         playermanager.WoodCollected();
         Destroy(gameObject);            
     }
}
}
