using UnityEngine;

public class PenaltySphere : MonoBehaviour {
    public RollerBall rollerBallGame;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Ball>() != null) {
            rollerBallGame.OnPenaltySphereCollected();
        }
    }
}
