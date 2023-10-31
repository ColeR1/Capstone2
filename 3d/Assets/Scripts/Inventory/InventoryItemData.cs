using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(menuName = "Inventory System/ Inventory Item")]

public class InventoryItemData : ScriptableObject
{
    public int ID;
    public string displayName;
    [TextArea(4,4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
}
