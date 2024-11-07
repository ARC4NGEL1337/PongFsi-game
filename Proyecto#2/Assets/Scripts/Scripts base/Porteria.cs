using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteria : MonoBehaviour
{
    public int maxHits = 3;
    private int currentHits = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentHits++;

            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}