using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {
    public Player player;
    public InventoryManager inventoryManager;

    private PlayerDamage playerDamage;

    private void Awake() {
        MiniGameManager.OnMiniGameFailed += MiniGameFailed;
        MiniGameManager.OnMiniGameSolved += MiniGameSolved;
    }

    private void MiniGameSolved(object sender, OnSolvedEvent onSolvedEvent) {
        inventoryManager.AddItem(onSolvedEvent.prize);
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
