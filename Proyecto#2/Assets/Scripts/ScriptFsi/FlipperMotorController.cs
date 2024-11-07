using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMotorController : MonoBehaviour
{
    public KeyCode activationKey;
    public float motorForce = 1000f;
    public float motorSpeed = 1000f;
    public float returnDelay = 0.2f;
    public int maxUses = 5;

    private HingeJoint hinge;
    private JointMotor motor;
    private int currentUses;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        currentUses = maxUses;

        motor = hinge.motor;
        motor.force = motorForce;
    }

    void Update()
    {
        if (Input.GetKeyDown(activationKey) && currentUses > 0)
        {
            ActivateFlipper();
            currentUses--;

            Invoke("DeactivateFlipper", returnDelay);
        }
    }

    void ActivateFlipper()
    {
        // Activar el motor para mover el flipper hacia el l�mite m�nimo.
        motor.targetVelocity = -motorSpeed; // Usar velocidad negativa para mover hacia el l�mite inferior.
        hinge.motor = motor;
        hinge.useMotor = true;
    }

    void DeactivateFlipper()
    {
        // Activar el motor para mover el flipper hacia el l�mite m�ximo.
        motor.targetVelocity = motorSpeed; // Usar velocidad positiva para regresar al l�mite superior.
        hinge.motor = motor;
        hinge.useMotor = true;
    }
}