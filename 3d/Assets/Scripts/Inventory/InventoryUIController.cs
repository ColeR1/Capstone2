using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    public DynamicInventoryDisplay chestDisplay;
    public DynamicInventoryDisplay playerBackpackPanel;

    private void Awake() {
        chestDisplay.gameObject.SetActive(false);
        playerBackpackPanel.gameObject.SetActive(false);
    }

    private void OnEnable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDisplayRequested += DisplayPlayerBackpack;
    }

    private void OnDisable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDisplayRequested -= DisplayPlayerBackpack;
    }

     void Update() 
    {
        if(chestDisplay.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame) chestDisplay.gameObject.SetActive(false);
        if(playerBackpackPanel.gameObject.activeInHierarchy && Keyboard.current.escapeKey.wasPressedThisFrame) playerBackpackPanel.gameObject.SetActive(false);
    }

    void DisplayInventory(InventorySystem invToDisplay)
    {
        chestDisplay.gameObject.SetActive(true);
        chestDisplay.RefreshDynamicInventory(invToDisplay);
    }
    void DisplayPlayerBackpack(InventorySystem invToDisplay)
    {
        playerBackpackPanel.gameObject.SetActive(true);
        playerBackpackPanel.RefreshDynamicInventory(invToDisplay);
    }
}
