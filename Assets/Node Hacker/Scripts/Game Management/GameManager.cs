using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public Player player;
    private PlayerDamage playerDamage;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        MiniGameManager.OnMiniGameFailed += MiniGameFailed;
        MiniGameManager.OnMiniGameSolved += MiniGameSolved;
    }

    private void MiniGameSolved(object sender, OnSolvedEvent onSolvedEvent) {
        InventoryManager.instance.AddItem(onSolvedEvent.prize);
    }

    private void MiniGameFailed(object sender, OnFailedEvent onFailedEvent) {
        if (playerDamage == null) {
            playerDamage = player.gameObject.GetComponent<PlayerDamage>();
        }
        if (playerDamage != null) {
            playerDamage.TakeDamage(onFailedEvent.damage);
        } else {
            Debug.LogError("Your player needs a player damage component");
        }
    }
}
