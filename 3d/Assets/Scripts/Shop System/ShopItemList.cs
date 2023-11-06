using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Shop System/ Shop Item List")]
public class ShopItemList : ScriptableObject
{
    [SerializeField] private List<ShopInventoryItem> _items;
    [SerializeField] private int _maxAllowedGold;
    [SerializeField] private float _sellMarkUp;
    [SerializeField] private float _buyMarkUp;

    public List<ShopInventoryItem> Items => _items;
    public int MaxAllowedGold => _maxAllowedGold;
    public float sellMarkUp => _sellMarkUp;
    public float buyMarkUp => _buyMarkUp;

    internal void AddToShop(InventoryItemData itemData, int amount)
    {
        throw new NotImplementedException();
    }
}


[System.Serializable]
public struct ShopInventoryItem
{
    public InventoryItemData ItemData;
    public int Amount;   
}
