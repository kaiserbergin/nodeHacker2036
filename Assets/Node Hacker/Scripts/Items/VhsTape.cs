using System;
using System.Collections.Generic;
using UnityEngine;

public class VhsTape : MonoBehaviour, IItem {
    //Interface Properties
    public Guid ItemId { get; private set; }
    public ItemTypes ItemType { get; private set; }
    public String ItemName { get; set; }

    //Public facing setters for editor
    public String itemName;

    public List<string> acceptableTags;

    public void Initialize() {
        ItemId = Guid.NewGuid();
        ItemName = itemName;
        ItemType = ItemTypes.VHS_TAPE;
    }

    private void Awake() {        
        if(ItemName == null) {
            Initialize();
        }
    }
}