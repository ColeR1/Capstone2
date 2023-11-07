using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager;
public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlot AssignedInventorySlot;

    private Transform _playerTransform;

    public float _dropOffset;

    private void Awake() {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
        ItemSprite.preserveAspect = true;

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(_playerTransform == null) Debug.Log("Player not found!");
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventorySlot.AssignItem(invSlot);
        UpdateMouseSlot();
    }
    public void UpdateMouseSlot()
    {
        ItemSprite.sprite = AssignedInventorySlot.ItemData.Icon;
        ItemCount.text = AssignedInventorySlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }


    private void Update() {
        if(AssignedInventorySlot.ItemData != null)
        {
            transform.position = Mouse.current.position.ReadValue();

            if(Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
                if(AssignedInventorySlot.ItemData.ItemPrefab !=null )Instantiate(AssignedInventorySlot.ItemData.ItemPrefab,_playerTransform.position +_playerTransform.forward * _dropOffset,Quaternion.identity);
                
                if(AssignedInventorySlot.StackSize > 1)
                {
                    AssignedInventorySlot.AddToStack(-1);
                    UpdateMouseSlot();
                }
                else
                {
                    ClearSlot();
                }
                
            }
        }
    }

    public void ClearSlot()
    {
        AssignedInventorySlot.ClearSlot();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> resulst = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, resulst);
        return resulst.Count > 0;
    }

}
