using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Lanza la pelota en una dirección aleatoria
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector3 direction = new Vector3(x, y, 0);
        rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Aumenta ligeramente la velocidad de la pelota cada vez que colisiona
        rb.velocity *= 1.05f;
    }
}
