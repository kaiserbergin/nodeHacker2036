
public class InventorySlot {
    public IItem item;
    public int count;

    public InventorySlot(IItem item, int count) {
        this.item = item;
        this.count = count;
    }

    public void AddCount(int count) {
        this.count += count;
    }

    public void RemoveCount(int count) {
        this.count -= count;
    }
}
