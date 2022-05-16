using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints = 6;
    GameObject parentGameObject;
    
    [Header("Score")]
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 15;

    void Awake()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
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
        GameObject vfx = Instantiate(hitVFX, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(this.gameObject);
    }
}
