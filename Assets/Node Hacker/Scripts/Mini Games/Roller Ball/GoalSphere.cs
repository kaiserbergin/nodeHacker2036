using UnityEngine;

public class GoalSphere : MonoBehaviour {
    public RollerBall rollerBallGame;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Ball>() != null) {
            rollerBallGame.OnGoalSphereCollected();
            gameObject.SetActive(false);
        }
    }
}
