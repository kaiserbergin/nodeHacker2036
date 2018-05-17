using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
    public GameManager gameManager;
    public AudioManager audioManager;
    public InventoryManager inventoryManager;
    public MiniGameManager miniGameManager;

    // Use this for initialization
    void Awake() {
        if (GameManager.instance == null) {
            Instantiate(gameManager);
        }
        if (AudioManager.instance == null) {
            Instantiate(audioManager);
        }
        if (InventoryManager.instance == null) {
            Instantiate(inventoryManager);
        }
        if (MiniGameManager.instance == null) {
            Instantiate(miniGameManager);
        }
    }
}
