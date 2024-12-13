using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour

{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    public LayerMask collisionLayer; // collision camera
    public float minDistance = 0.5f; // distance

    private void LateUpdate()
    {
        // position
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        // Comprobar colisiones
        if (Physics.Linecast(player.position, desiredPosition, out RaycastHit hit, collisionLayer))
        {
            // collision check
            desiredPosition = hit.point + hit.normal * minDistance;
        }

        // Smooth
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // set position
        transform.position = smoothedPosition;

        // look the player
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}





