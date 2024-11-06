using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttractionController : MonoBehaviour
{
    public Transform leftPaddleAnchor; // Punto de anclaje del jugador izquierdo
    public Transform rightPaddleAnchor; // Punto de anclaje del jugador derecho
    public KeyCode leftPlayerKey = KeyCode.Q; // Tecla para atraer la pelota hacia el paddle izquierdo
    public KeyCode rightPlayerKey = KeyCode.P; // Tecla para atraer la pelota hacia el paddle derecho
    public float springForce = 50f; // Fuerza del resorte
    public float damper = 2f; // Amortiguador para suavizar el movimiento
    public int maxUsesPerPlayer = 2; // Número máximo de usos por jugador

    private int leftPlayerUses = 0;
    private int rightPlayerUses = 0;

    void Update()
    {
        // Comprobar si el jugador izquierdo presiona la tecla y tiene usos disponibles
        if (Input.GetKeyDown(leftPlayerKey) && leftPlayerUses < maxUsesPerPlayer)
        {
            ActivateSpring(leftPaddleAnchor);
            leftPlayerUses++;
        }

        // Comprobar si el jugador derecho presiona la tecla y tiene usos disponibles
        if (Input.GetKeyDown(rightPlayerKey) && rightPlayerUses < maxUsesPerPlayer)
        {
            ActivateSpring(rightPaddleAnchor);
            rightPlayerUses++;
        }
    }

    void ActivateSpring(Transform anchor)
    {
        // Crear el Spring Joint dinámicamente
        SpringJoint springJoint = gameObject.AddComponent<SpringJoint>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = anchor.position;
        springJoint.spring = springForce;
        springJoint.damper = damper;

        // Destruir el Spring Joint después de un breve retraso para evitar una conexión permanente
        Destroy(springJoint, 0.5f);
    }
}