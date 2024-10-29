using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMotorController : MonoBehaviour
{
    public KeyCode activationKey; // La tecla que activar� la paleta
    public float motorForce = 1000f; // Fuerza del motor
    public float motorSpeed = 1000f; // Velocidad del motor
    public float returnDelay = 0.2f; // Retraso para regresar a la posici�n original
    public int maxUses = 5; // N�mero m�ximo de usos

    private HingeJoint hinge;
    private JointMotor motor;
    private int currentUses;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        currentUses = maxUses;

        // Configurar el motor inicialmente
        motor = hinge.motor;
        motor.force = motorForce;
    }

    void Update()
    {
        if (Input.GetKeyDown(activationKey) && currentUses > 0)
        {
            ActivateFlipper();
            currentUses--;

            // Iniciar un retorno despu�s de un breve retraso
            Invoke("DeactivateFlipper", returnDelay);
        }
    }

    void ActivateFlipper()
    {
        // Activar el motor para mover el flipper hacia el l�mite m�nimo (de pie)
        motor.targetVelocity = -motorSpeed; // Usar velocidad negativa para mover hacia el l�mite inferior
        hinge.motor = motor;
        hinge.useMotor = true;
    }

    void DeactivateFlipper()
    {
        // Activar el motor para mover el flipper hacia el l�mite m�ximo (reposo)
        motor.targetVelocity = motorSpeed; // Usar velocidad positiva para regresar al l�mite superior
        hinge.motor = motor;
        hinge.useMotor = true;
    }
}