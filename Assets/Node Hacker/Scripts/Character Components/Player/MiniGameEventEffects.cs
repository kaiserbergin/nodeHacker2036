using UnityEngine;
using System.Collections;

public class MiniGameEventEffects : MonoBehaviour {
    public Player player;
    public PlayerDamage playerDamage;

    private void Awake() {
        MiniGameManager.OnMiniGameFailed += MiniGameFailed;
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
