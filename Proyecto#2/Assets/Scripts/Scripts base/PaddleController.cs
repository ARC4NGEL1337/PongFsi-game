using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string inputAxis;

    void Update()
    {
        float move = Input.GetAxis(inputAxis) * speed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Limitar el movimiento del paddle para que no se salga del campo
        float clampedY = Mathf.Clamp(transform.position.y, -1f, 6f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
