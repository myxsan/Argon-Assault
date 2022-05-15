using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    [Header("Score")]
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;

    private void Awake() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other) {
        Debug.Log($"{this.gameObject.name} : hit by {other.gameObject.name}");
        GameObject vfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        scoreBoard.IncreaseScore(scorePerHit);
        Destroy(this.gameObject);
    }
}
