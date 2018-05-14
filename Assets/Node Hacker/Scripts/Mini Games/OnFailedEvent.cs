using System;

public class OnFailedEvent : EventArgs {
    public Guid gameId;
    public int damage;
    public String message;

    public OnFailedEvent(Guid gameId, int damage, String message) {
        this.gameId = gameId;
        this.damage = damage;
        this.message = message;
    }
}
