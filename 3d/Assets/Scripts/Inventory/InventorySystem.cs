using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;
using Unity.VisualScripting;


[System.Serializable]
public class InventorySystem
{
    [SerializeField] private  List<InventorySlot> inventorySlots;
     private int _gold;

    public int Gold => _gold;

    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;
    public UnityAction<InventorySlot> onInventorySlotChanged;

    public InventorySystem(int size)
    {
        _gold = 0;

        CreateInventory(size);
    }

    public InventorySystem(int size, int gold)
    {
        _gold = gold;
        CreateInventory(size);
    }

    private void CreateInventory(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for(int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }
    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd)
    {
        if(ContainsItem(itemToAdd, out List<InventorySlot> invSlot))
        {
           foreach ( var slot in invSlot)
           {
            if(slot.RoomLeftInStack(amountToAdd))
            {
                slot.AddToStack(amountToAdd);
                onInventorySlotChanged?.Invoke(slot);
                return true;
            }
           }
        }

        if(HasFreeSlot(out InventorySlot freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            onInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }

    public bool ContainsItem(InventoryItemData itemToAdd, out List<InventorySlot> invSlot)
    {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();
        Debug.Log(invSlot.Count);
        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }

    internal bool CheckInventoryRemaining(Dictionary<InventoryItemData, int> shoppingCart)
    {
        var clonedSystem = new InventorySystem(this.InventorySize);

        for(int i = 0; i<InventorySize; i++)
        {
            clonedSystem.InventorySlots[i].AssignItem(this.InventorySlots[i].ItemData,this.InventorySlots[i].StackSize);
        }

        foreach (var kvp in shoppingCart)
        {
            for(int i = 0; i< kvp.Value; i++)
            {
                if(!clonedSystem.AddToInventory(kvp.Key,1)) return false;
            }
        }

        return true;
    }

    internal void SpendGold(int basketTotal)
    {
        _gold -= basketTotal;
    }

    public Dictionary<InventoryItemData, int> GetAllItemsHeld()
    {
        var distinctItems = new Dictionary<InventoryItemData, int>();

        foreach (var item in inventorySlots)
        {
            if(item.ItemData == null) continue;

            if(!distinctItems.ContainsKey(item.ItemData)) distinctItems.Add(item.ItemData, item.StackSize);
            else distinctItems[item.ItemData] += item.StackSize;
        }

        return distinctItems;
    }

    internal void GainGold(int price)
    {
        _gold += price;
    }

    internal void RemoveItemsFromInventory(InventoryItemData data, int amount)
    {
        if(ContainsItem(data, out List<InventorySlot> invSlot))
        {
            foreach (var slot in invSlot)
            {
                var StackSize = slot.StackSize;

                if(StackSize > amount) slot.RemoveFromStack(amount);
                else
                {
                    slot.RemoveFromStack(StackSize);
                    amount -= StackSize;
                }

                onInventorySlotChanged?.Invoke(slot);
            }
        }
    }
}
