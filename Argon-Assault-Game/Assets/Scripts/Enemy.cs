using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    [SerializeField] int hitPoints = 6;

    [Header("Score")]
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;

    private void Awake() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        HitProcess();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void HitProcess()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints--;
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
