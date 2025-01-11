using UnityEngine;

//public class MoverCoche : MonoBehaviour
//{
//    public Transform destino; // Punto objetivo
//    private CarController carController; // Referencia al controlador del coche

//    void Start()
//    {
//        // Obtén el controlador del coche
//        carController = GetComponent<CarController>();
//    }

//    void Update()
//    {
//        // Opcional: Actualiza el destino en tiempo real
//        if (destino != null)
//        {
//            MoveCarToDestination();
//        }
//    }

//    private void MoveCarToDestination()
//    {
//        // Calcula la dirección hacia el destino
//        Vector3 directionToDestination = (destino.position - transform.position).normalized;

//        // Obtiene el ángulo entre la dirección del coche y la dirección hacia el destino
//        float angleToDestination = Vector3.SignedAngle(transform.forward, directionToDestination, Vector3.up);

//        // Ajusta la entrada de dirección en función del ángulo
//        float horizontalInput = Mathf.Clamp(angleToDestination / 45f, -1f, 1f);

//        // Aplica la dirección al controlador del coche
//        carController.SetHorizontalInput(horizontalInput);

//        // Control de la velocidad: el coche avanza hacia el destino
//        float verticalInput = 1f; // El coche avanza constantemente hacia el destino
//        carController.SetVerticalInput(verticalInput);

//        // Frenado: detén el coche si está demasiado cerca del destino
//        float distanceToDestination = Vector3.Distance(transform.position, destino.position);
//        if (distanceToDestination < 2f) // Distancia de frenado
//        {
//            carController.SetBreaking(true);
//        }
//        else
//        {
//            carController.SetBreaking(false);
//        }
//    }
//}

using UnityEngine;
using UnityEngine.AI; // Necesario para usar NavMesh

public class MoverCoche : MonoBehaviour
{
    public Transform destino; // El destino hacia donde el coche debe moverse
    private NavMeshAgent navMeshAgent; // El agente NavMesh
    public float stopDistance = 7f; // Distancia mínima para detenerse

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtiene el NavMeshAgent
        if (navMeshAgent != null && destino != null)
        {
            navMeshAgent.SetDestination(destino.position); // Asigna el destino inicial
        }
    }

    void Update()
    {
        if (destino != null && navMeshAgent != null)
        {
            // Siempre actualiza el destino en tiempo real
            navMeshAgent.SetDestination(destino.position);

            // Si la distancia restante es menor que la distancia de parada, detén el coche
            if (navMeshAgent.remainingDistance <= stopDistance && !navMeshAgent.pathPending)
            {
                navMeshAgent.isStopped = true; // Detiene el agente
            }
            else
            {
                navMeshAgent.isStopped = false; // Asegura que el agente sigue moviéndose si aún no ha llegado
            }
        }
    }
}








