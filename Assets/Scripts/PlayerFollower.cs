using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour {

    public Transform player;
    public float moveSpeed = 2.5f;

    void FixedUpdate() {
        if (IsOnSamePlatform()) {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 movement = direction * moveSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }

    bool IsOnSamePlatform() {
        RaycastHit enemyHit, playerHit;
        bool enemyGrounded = Physics.Raycast(transform.position, -Vector3.up, out enemyHit, 1f);
        bool playerGrounded = Physics.Raycast(player.position, -Vector3.up, out playerHit, 1f);
        if (enemyGrounded && playerGrounded) {
            return enemyHit.collider == playerHit.collider;
        }
        return false;
    }
}
