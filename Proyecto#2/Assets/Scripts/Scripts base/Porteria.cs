using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteria : MonoBehaviour
{
    public int maxHits = 3; // N�mero m�ximo de golpes antes de destruir el cubo
    private int currentHits = 0; // Contador de los golpes recibidos

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que golpea es la pelota
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentHits++;

            // Destruir el cubo si alcanza el n�mero m�ximo de golpes
            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}