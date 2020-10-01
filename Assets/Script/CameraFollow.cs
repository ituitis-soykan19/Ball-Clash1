using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Transform targets;

    public float smoothspeed = 1.5f;

    public Vector3 offset;
    private void LateUpdate()
    {
        float smooth = 5.0f;
        float tiltAngle = 5.0f;
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        offset = new Vector3(0.0f, 4.0f, -16.0f);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothedPosition;
        Quaternion targets = Quaternion.Euler(0, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targets, Time.deltaTime * smooth);
    }
}
