using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuoyancyEffect : MonoBehaviour
{
    public float waveSpeed;
    public float waveMagnitude;
    private BuoyancyEffector2D buoyancy;
    private float newDensity;

    private void Start()
    {
        buoyancy = GetComponent<BuoyancyEffector2D>();

    }

    private void Update()
    {
        newDensity = Mathf.Sin(Time.time * waveSpeed) * waveMagnitude;
        buoyancy.density = newDensity;
    }
    
}
