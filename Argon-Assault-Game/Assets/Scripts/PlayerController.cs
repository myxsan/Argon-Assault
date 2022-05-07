using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xThrow, yThrow;
    [Header("Movement Speeds")]
    [SerializeField] float xControlSpeed = 2f;
    [SerializeField] float yControlSpeed = 1f;
    
    [Header("Position Range")]
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [Header("Rotation Factors")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] GameObject[] lasers;

    

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        FiringProcess();
    }



    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        this.transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * xControlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * yControlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange + 7, yRange);

        transform.localPosition = new Vector3
                                (clampedXPos,
                                clampedYPos,
                                transform.localPosition.z);
    }    
    void FiringProcess()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasers(true);
        }
        else
        {
            SetLasers(false);
        }
    }

    private void SetLasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.gameObject.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
