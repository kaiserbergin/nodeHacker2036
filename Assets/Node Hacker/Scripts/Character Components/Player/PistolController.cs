using UnityEngine;

public class PistolController : MonoBehaviour {
    public float pistolCooldownTime = .25f;
    private float lastFired = 0f;

    public FireProjectile fireProjectile;

    public GameObject projectileOrigin;

    public void FirePistol() {
        if(fireProjectile != null && projectileOrigin != null && Time.time - lastFired >= pistolCooldownTime) {
            lastFired = Time.time;
            fireProjectile.FireForward(projectileOrigin.transform);
        }
    }
}
