using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PedirUI pedirUI; // Referencia al script PedirUI
    public GameObject destination; // Destino al que el taxi debe ir
    public GameObject taxi;
    public Transform positionPlayer;

    public float arrivalDistance = 10f;
    public bool isTaxiCalled = false;

    private void Update()
    {
        // Verifica si el taxi ha sido llamado
        if (isTaxiCalled)
        {
            SetDestination();
        }
        isTaxiCalled = false;
        CheckTaxiArrival();
    }

    // Método para mover el taxi hacia el destino
    private void SetDestination()
    {
        destination.transform.position = positionPlayer.position;
    }

    private void CheckTaxiArrival()
    {
        float distance = Vector3.Distance(taxi.transform.position, positionPlayer.position); // Distancia entre el taxi y el jugador

        if (distance <= arrivalDistance)
        {
            pedirUI.TaxiArrive();
        }
    }
}


