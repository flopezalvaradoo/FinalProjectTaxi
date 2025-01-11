using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Radar : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private float speedLimit = 100f; // Límite de velocidad en km/h
    [SerializeField] private MoverPolicia policeCar; // Referencia al coche de policía

    private bool isPursuing = false;

    private void Update()
    {
        float currentSpeed = carController.GetSpeed();

        // Si el jugador supera el límite de velocidad y la policía no está persiguiendo
        if (currentSpeed > speedLimit && !isPursuing)
        {
            Debug.Log("¡Exceso de velocidad detectado! Activando la policía...");
            isPursuing = true;
            policeCar.ActivarPersecucion(carController.transform);
        }
    }

    // Este método se llamará cuando la policía detenga la persecución
    public void ReiniciarRadar()
    {
        isPursuing = false;
        Debug.Log("El radar está listo para detectar otro exceso de velocidad.");
    }
}
