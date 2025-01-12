using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> spawnPoints; // Lista de puntos de spawn
    public float detectionRadius = 5f; // Radio para detectar al taxi
    public GameManager2 gameManager;
    public CarController car;

    private bool isPickedUp = false;   // Control interno para evitar múltiples detecciones

    void Start()
    {

        // Buscar el hijo con la posición correcta
        Vector3 playerPosition = GetRandomDestination();

        // Obtener la posición solo en X y Z
        Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);

        // Establecer la posición del jugador
        transform.position = newPosition;
    }

    public void cogerTaxi()
    {
        if (isPickedUp || gameManager == null) return;

        // Calcular la distancia al taxi
        float distanceToTaxi = Vector3.Distance(transform.position, car.transform.position);

        if (distanceToTaxi <= detectionRadius)
        {
            // El taxi está lo suficientemente cerca
            isPickedUp = true; // Evitar múltiples detecciones
            gameManager.HasPlayer = true; // Actualizar el estado del taxi

            // Desactivar al jugador (desaparece del mundo)
            gameObject.SetActive(false);
            
        }
        
    }

    public void dejarTaxi()
    {

        // Calcular la distancia al taxi
        float distanceToTaxi = Vector3.Distance(car.transform.position, gameManager.finalPosition);

        if (distanceToTaxi <= detectionRadius)
        {
            Vector3 vector = new Vector3(gameManager.finalPosition.x, 3.27f, gameManager.finalPosition.z);
            gameObject.transform.position = vector;
            gameObject.SetActive(true);
            gameManager.finalJuego = true;
        }

    }


    public Vector3 GetRandomDestination()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        Transform childWithPosition = randomSpawnPoint.GetChild(0);

        return childWithPosition.position;
    }
}

