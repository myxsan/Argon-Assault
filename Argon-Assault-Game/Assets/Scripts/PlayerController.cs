using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] float xControlSpeed = 2f;
    [SerializeField] float yControlSpeed = 1f;
    
    [Header("Position Range")]
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;
    void Start()
    {
        
    }


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        this.transform.localRotation = Quaternion.Euler(-30, 30 , 0);
    }

    void ProcessTranslation()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

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
}
