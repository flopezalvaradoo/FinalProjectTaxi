using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Si estás usando TextMeshPro

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button callTaxiButton; // Referencia al botón
    [SerializeField] private Transform car; // El coche al que se le da la orden
    [SerializeField] private float speed = 5f; // Velocidad del coche
    [SerializeField] private Transform destination; // Destino al que el coche debe ir

    private bool isTaxiCalled = false;

    void Start()
    {
        // Asegúrate de que el botón esté asignado en el inspector
        if (callTaxiButton != null)
        {
            callTaxiButton.onClick.AddListener(CallTaxi); // Asignamos la función al botón
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
        // Se llama al taxi cuando se presiona el botón
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

