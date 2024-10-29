using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWind : MonoBehaviour
{
    public Cloth clothComponent;

    public Vector3 windMin = new Vector3(5f, 0f, 0f);
    public Vector3 windMax = new Vector3(15f, 0f, 0f);

    public float windChangeInterval = 3f;

    private float timeSinceLastChange = 0f;

    void Start()
    {
        if (clothComponent == null)
        {
            clothComponent = GetComponent<Cloth>();
        }
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;

        if (timeSinceLastChange >= windChangeInterval)
        {
            Vector3 randomWind = new Vector3(
                Random.Range(windMin.x, windMax.x),
                Random.Range(windMin.y, windMax.y),
                Random.Range(windMin.z, windMax.z)
            );

            clothComponent.externalAcceleration = randomWind;

            timeSinceLastChange = 0f;
        }
    }
}