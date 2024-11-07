using UnityEngine;

public class BuffEffect : MonoBehaviour
{
    public enum BuffType { Impulso, Aceleracion, Fuerza }
    public BuffType tipoBuff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Detecta si la Bola de Juego toca el Buff
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            if (ballRb != null)
            {
                switch (tipoBuff)
                {
                    case BuffType.Impulso:
                        ballRb.AddForce(ballRb.velocity.normalized * 500f, ForceMode.Impulse);
                        break;

                    case BuffType.Aceleracion:
                        ballRb.AddForce(ballRb.velocity.normalized * 200f, ForceMode.Force);
                        break;

                    case BuffType.Fuerza:
                        ballRb.AddForce(Vector3.up * 300f, ForceMode.Force);
                        break;
                }
            }

            Destroy(gameObject); // Elimina el Buff al activarse
        }
    }
}
