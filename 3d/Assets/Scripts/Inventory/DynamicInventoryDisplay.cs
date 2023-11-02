using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class DynamicInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefab;
    protected override void Start()
    {
        base.Start();

    }
    public void RefreshDynamicInventory(InventorySystem invToDisplay)
    {
        ClearSlot();
        inventorySystem = invToDisplay;
        if(inventorySystem != null)inventorySystem.onInventorySlotChanged += UpdateSlot;
        AssignSlot(invToDisplay);
    }

    public override void AssignSlot(InventorySystem invToDIsplay)
    {
        ClearSlot();

        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if(invToDIsplay == null) return;

        for (int i = 0; i < invToDIsplay.InventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDIsplay.InventorySlots[i]);
            uiSlot.Init(invToDIsplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }
    }

    private void ClearSlot()
    {
        foreach(var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }

        if(slotDictionary != null) slotDictionary.Clear();
    }

    private void OnDisable() {
        if(inventorySystem != null) inventorySystem.onInventorySlotChanged -= UpdateSlot;
    }
}
