using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int hitPoints = 6;

    [Header("Score")]
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;

    void Awake()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void Start()
    {
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody enemyRb = gameObject.AddComponent<Rigidbody>();
        enemyRb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        HitProcess();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void HitProcess()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints--;
        GameObject hvfx = Instantiate(hitVFX, this.transform.position, Quaternion.identity);
        hvfx.transform.parent = parent;
    }

    void KillEnemy()
    {
        GameObject dvfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
        dvfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
