using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        MiniGameManager.OnMiniGameSolved += MiniGameSolved;
    }

    private void MiniGameSolved(object sender, OnSolvedEvent onSolvedEvent) {
        InventoryManager.instance.AddItem(onSolvedEvent.prize);
    }
}
