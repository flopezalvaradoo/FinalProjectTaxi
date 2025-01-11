using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoverPolicia : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Transform target;
    private bool enPersecucion = false;
    private float detectionDistance = 10f; // Distancia de detecci�n para la multa

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Radar radar; // Referencia al radar

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.isStopped = true;

        initialPosition = transform.position;
        initialRotation = transform.rotation;

        radar = FindObjectOfType<Radar>(); // Encuentra el radar en la escena
    }

    void Update()
    {
        if (enPersecucion && target != null)
        {
            navMeshAgent.SetDestination(target.position);

            // Comprobar la distancia al jugador
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget <= detectionDistance)
            {
                MultarJugador();
            }
        }
    }

    public void ActivarPersecucion(Transform jugador)
    {
        navMeshAgent.isStopped = false;
        target = jugador;
        enPersecucion = true;
        Debug.Log("La polic�a ha comenzado la persecuci�n.");
    }

    private void MultarJugador()
    {
        Debug.Log("La polic�a ha detectado tu matr�cula y te ha puesto una multa.");
        RespawnPoliceCar();
    }

    public void DetenerPersecucion()
    {
        navMeshAgent.isStopped = true;
        enPersecucion = false;
        Debug.Log("La polic�a ha detenido la persecuci�n.");
    }

    private void RespawnPoliceCar()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        DetenerPersecucion();

        // Notificar al radar que puede detectar otro exceso de velocidad
        if (radar != null)
        {
            radar.ReiniciarRadar();
        }

        Debug.Log("El coche de polic�a ha reaparecido en su posici�n inicial.");
    }
}
