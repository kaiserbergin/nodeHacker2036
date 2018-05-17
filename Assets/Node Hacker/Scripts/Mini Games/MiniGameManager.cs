using System;
using UnityEngine;

public class MiniGameManager : MonoBehaviour {
    public static MiniGameManager instance;    

    //Minigame events
    public static event EventHandler<OnSolvedEvent> OnMiniGameSolved = delegate { };
    public static event EventHandler<OnFailedEvent> OnMiniGameFailed = delegate { };

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void MiniGameSolved(Guid gameId, IItem prize, String message) {
        OnMiniGameSolved(this, new OnSolvedEvent(gameId, prize, message));
    }

    public void MiniGameFailed(Guid gameId, int damage, String message) {
        OnMiniGameFailed(this, new OnFailedEvent(gameId, damage, message));

    }
}
