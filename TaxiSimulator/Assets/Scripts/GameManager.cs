using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Si est�s usando TextMeshPro

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button callTaxiButton; // Referencia al bot�n
    [SerializeField] private Transform car; // El coche al que se le da la orden
    [SerializeField] private float speed = 5f; // Velocidad del coche
    [SerializeField] private Transform destination; // Destino al que el coche debe ir

    private bool isTaxiCalled = false;

    void Start()
    {
        // Aseg�rate de que el bot�n est� asignado en el inspector
        if (callTaxiButton != null)
        {
            callTaxiButton.onClick.AddListener(CallTaxi); // Asignamos la funci�n al bot�n
        }
    }

    void Update()
    {
        if (isTaxiCalled)
        {
            // Mover el coche hacia el destino
            MoveCarTowardsDestination();
        }
    }

    private void CallTaxi()
    {
        // Se llama al taxi cuando se presiona el bot�n
        isTaxiCalled = true;
        Debug.Log("Taxi llamado. El coche se dirige hacia el destino.");
    }

    private void MoveCarTowardsDestination()
    {
        // Mover el coche hacia el destino
        Vector3 direction = (destination.position - car.position).normalized;
        car.position += direction * speed * Time.deltaTime;

        // Comprobar si ha llegado al destino
        if (Vector3.Distance(car.position, destination.position) < 2f)
        {
            isTaxiCalled = false;
            Debug.Log("Taxi ha llegado.");
        }
    }
}

