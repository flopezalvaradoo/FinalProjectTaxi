using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Radar : MonoBehaviour
{
    [SerializeField] private CarController carController;
    [SerializeField] private float speedLimit = 100f; // L�mite de velocidad en km/h
    [SerializeField] private MoverPolicia policeCar; // Referencia al coche de polic�a

    private bool isPursuing = false;

    private void Update()
    {
        float currentSpeed = carController.GetSpeed();

        // Si el jugador supera el l�mite de velocidad y la polic�a no est� persiguiendo
        if (currentSpeed > speedLimit && !isPursuing)
        {
            Debug.Log("�Exceso de velocidad detectado! Activando la polic�a...");
            isPursuing = true;
            policeCar.ActivarPersecucion(carController.transform);
        }
    }

    // Este m�todo se llamar� cuando la polic�a detenga la persecuci�n
    public void ReiniciarRadar()
    {
        isPursuing = false;
        Debug.Log("El radar est� listo para detectar otro exceso de velocidad.");
    }
}
