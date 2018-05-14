using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public List<InventorySlot> inventorySlots;

    public void AddItem(IItem item) {
        int matchedInventorySlotIndex = inventorySlots.FindIndex(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlotIndex >= 0) {
            inventorySlots[matchedInventorySlotIndex].AddCount(1);
        } else {
            item.Initialize();
            inventorySlots.Add(new InventorySlot(item, 1));
        }
    }

    public void AddItem(IItem item, int count) {
        int matchedInventorySlotIndex = inventorySlots.FindIndex(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlotIndex >= 0) {
            inventorySlots[matchedInventorySlotIndex].AddCount(count);
        } else {
            item.Initialize();
            inventorySlots.Add(new InventorySlot(item, count));
        }
    }

    public void UseItem(IItem item) {
        int matchedInventorySlotIndex = inventorySlots.FindIndex(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlotIndex >= 0 && inventorySlots[matchedInventorySlotIndex].count > 0) {
            inventorySlots[matchedInventorySlotIndex].RemoveCount(1);
        } else {
            throw new System.InvalidOperationException("Cannot use an item that is not in the inventory.");
        }
    }

    public void UseItem(IItem item, int count) {
        int matchedInventorySlotIndex = inventorySlots.FindIndex(slot => slot.item.ItemType.Equals(item.ItemType));
        if (matchedInventorySlotIndex >= 0 && inventorySlots[matchedInventorySlotIndex].count > count) {
            inventorySlots[matchedInventorySlotIndex].RemoveCount(count);
        } else {
            throw new System.InvalidOperationException("Cannot use an item that is not in the inventory.");
        }
    }
}
