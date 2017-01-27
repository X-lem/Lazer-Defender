using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private float damage = 100f;

    public void Hit() {
        // Destroy the lazer
        Destroy(gameObject);
    }

    public float getDamage() {
        return damage;
    }
}
