using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
   private TextMeshProUGUI woodText;
 // Start is called before the first frame update
 void Start()
 {
     woodText = GetComponent<TextMeshProUGUI>();
 }

 // Update is called once per frame
 void Update()
 {

 }

 public void UpdateWoodText(PlayerManager playerManager)
 {
     woodText.text = playerManager.WoodCount.ToString();
 }
}
