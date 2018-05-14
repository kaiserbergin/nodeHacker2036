using System;
using UnityEngine;

public class SIN : MonoBehaviour {
    //Interface Properties
    public Guid ItemId { get; private set; }
    public ItemTypes ItemType { get; private set; }
    public String ItemName { get; set; }

    //Public facing setters for editor
    public String itemName;

    public void Initialize() {
        ItemName = itemName;
        ItemType = ItemTypes.SIN;
    }

    private void Awake() {
        ItemId = Guid.NewGuid();
    }
}
