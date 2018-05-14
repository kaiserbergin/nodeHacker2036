using System;

public class OnSolvedEvent : EventArgs {
    public Guid gameId;
    public IItem prize;
    public String message;

    public OnSolvedEvent(Guid gameId, IItem prize, String message) {
        this.gameId = gameId;
        this.prize = prize;
        this.message = message;
    }
}
