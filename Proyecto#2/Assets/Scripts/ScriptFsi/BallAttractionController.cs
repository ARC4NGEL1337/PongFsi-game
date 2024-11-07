using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttractionController : MonoBehaviour
{
    public Transform leftPaddleAnchor;
    public Transform rightPaddleAnchor;
    public KeyCode leftPlayerKey = KeyCode.Q;
    public KeyCode rightPlayerKey = KeyCode.P;
    public float springForce = 50f;
    public float damper = 2f;
    public int maxUsesPerPlayer = 2;

    private int leftPlayerUses = 0;
    private int rightPlayerUses = 0;

    void Update()
    {
        if (Input.GetKeyDown(leftPlayerKey) && leftPlayerUses < maxUsesPerPlayer)
        {
            ActivateSpring(leftPaddleAnchor);
            leftPlayerUses++;
        }

        if (Input.GetKeyDown(rightPlayerKey) && rightPlayerUses < maxUsesPerPlayer)
        {
            ActivateSpring(rightPaddleAnchor);
            rightPlayerUses++;
        }
    }

    void ActivateSpring(Transform anchor)
    {
        SpringJoint springJoint = gameObject.AddComponent<SpringJoint>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = anchor.position;
        springJoint.spring = springForce;
        springJoint.damper = damper;

        Destroy(springJoint, 0.5f);
    }
}