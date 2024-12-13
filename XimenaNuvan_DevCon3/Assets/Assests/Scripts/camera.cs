using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour

{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    public LayerMask collisionLayer; // Capas con las que la c�mara puede colisionar
    public float minDistance = 0.5f; // Distancia m�nima de la c�mara al jugador

    private void LateUpdate()
    {
        // Posici�n deseada
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        // Comprobar colisiones
        if (Physics.Linecast(player.position, desiredPosition, out RaycastHit hit, collisionLayer))
        {
            // Si hay colisi�n, ajusta la posici�n para que est� justo delante del obst�culo
            desiredPosition = hit.point + hit.normal * minDistance;
        }

        // Suavizar la posici�n de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asignar la posici�n
        transform.position = smoothedPosition;

        // Hacer que la c�mara mire al jugador
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}





