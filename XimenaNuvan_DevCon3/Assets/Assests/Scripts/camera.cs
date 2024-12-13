using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour

{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    public LayerMask collisionLayer; // Capas con las que la cámara puede colisionar
    public float minDistance = 0.5f; // Distancia mínima de la cámara al jugador

    private void LateUpdate()
    {
        // Posición deseada
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        // Comprobar colisiones
        if (Physics.Linecast(player.position, desiredPosition, out RaycastHit hit, collisionLayer))
        {
            // Si hay colisión, ajusta la posición para que esté justo delante del obstáculo
            desiredPosition = hit.point + hit.normal * minDistance;
        }

        // Suavizar la posición de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asignar la posición
        transform.position = smoothedPosition;

        // Hacer que la cámara mire al jugador
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}





