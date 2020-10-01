using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    public float smooth = 5.0f;
    public float tiltAngle = 0.0f;

    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = tiltAngle;
        float tiltAroundY = tiltAngle;
        float tiltAroundX = tiltAngle;
        tiltAngle = tiltAngle + 0.7f;


        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundY, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
