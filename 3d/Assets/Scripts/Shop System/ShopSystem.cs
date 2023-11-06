using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShortcutManagement;
using UnityEngine;

[System.Serializable]
public class ShopSystem
{
   [SerializeField] private List<ShopSlot> _shopInvnetory;
   [SerializeField] private int _availableGold;
   [SerializeField] private float _buyMarkUp;
   [SerializeField] private float _sellMarkUp;

   public ShopSystem(int size, int gold, float buyMarkUp, float sellMarkUp)
   {
    _availableGold = gold;
    _buyMarkUp = buyMarkUp;
    _sellMarkUp = sellMarkUp;

    SetShopSize(size);
   }

   private void SetShopSize(int size)
   {
        _shopInvnetory = new List<ShopSlot>(size);

        for(int i = 0; i<size; i++)
        {
            _shopInvnetory.Add(new ShopSlot());
        }
   }

   public void AddToShop(InventoryItemData data, int amount)
   {
    if(ContainsItem(data, out ShopSlot shopSlot))
    {
        shopSlot.AddToStack(amount);
    }

    var freeSlot = GetFreeSlot();
    freeSlot.AssignItem(data, amount);
   }

   private ShopSlot GetFreeSlot()
   {
    var freeSlot = _shopInvnetory.FirstOrDefault(i => i.ItemData == null);

    if(freeSlot == null)
    {
        freeSlot = new ShopSlot();
        _shopInvnetory.Add(freeSlot);
    }

    return freeSlot;
   }

   public bool ContainsItem(InventoryItemData itemToAdd, out ShopSlot shopSlot)
   {
    shopSlot = _shopInvnetory.Find(i => i.ItemData == itemToAdd);
    return shopSlot != null;

   }
}
