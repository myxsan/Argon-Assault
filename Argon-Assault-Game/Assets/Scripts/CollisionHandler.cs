using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] GameObject masterTimeline;
    
    private void OnCollisionEnter(Collision other) {
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        masterTimeline.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        crashVFX.Play();
        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
