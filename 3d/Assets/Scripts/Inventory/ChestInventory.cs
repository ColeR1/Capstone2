using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(UniqueID))]
public class ChestInventory : InventoryHolder, IInteractable
{
    public UnityAction<IInteractable> OnInteractionComplete {get; set;}

    protected override void Awake()
    {
        base.Awake();
        SaveLoad.OnLoadGame += LoadInventory;
    }

    private void Start() {
        var chestSaveData = new ChestSaveData(primaryInventorySystem, transform.position, transform.rotation);

        SaveGameManager.data.chestDictionary.Add(GetComponent<UniqueID>().ID, chestSaveData);
    }

    private void LoadInventory(SaveData data)
    {
        //Check the save data for this specific chests inventory, and if it exists, load it in
        if(data.chestDictionary.TryGetValue(GetComponent<UniqueID>().ID, out ChestSaveData chestData))
        {
            this.primaryInventorySystem = chestData.invSystem;
            this.transform.position = chestData.posiiton;
            this.transform.rotation = chestData.rotation;
        }
    }

    public void Interact(Interactor interactor, out bool interactSuccessful)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(primaryInventorySystem);
        interactSuccessful = true;
    }
    public void EndInteraction()
    {
        
    }  
}

[System.Serializable]
public struct ChestSaveData
{
    public InventorySystem invSystem;
    public Vector3 posiiton;
    public Quaternion rotation;

    public ChestSaveData(InventorySystem _invSystem, Vector3 _position, Quaternion _rotation)
    {
        invSystem = _invSystem;
        posiiton = _position;
        rotation = _rotation;
    }
}

