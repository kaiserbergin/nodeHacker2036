using System;

public enum ItemTypes {
    ESCAPE_KEY,
    RX_PILLS,
    SIN,
    VHS_TAPE
}

public interface IItem {
    Guid ItemId { get; }
    ItemTypes ItemType { get; }
    String ItemName { get; set; }

    void Initialize();
}