using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 vel;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        vel = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D other) { 
            var speed = vel.magnitude;
            var direction = Vector3.Reflect(vel.normalized, other.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
