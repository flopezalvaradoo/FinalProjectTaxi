using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PedirUI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 5f;
    private bool isTaxiCalled = false;

    [SerializeField] private Button callTaxiButton;  // Referencia al botón
    [SerializeField] private TMP_Text statusText;    // Referencia al TextMeshPro para mostrar el estado

    private void Start()
    {
        // Asignar la función al botón
        if (callTaxiButton != null)
        {
            callTaxiButton.onClick.AddListener(CallTaxi);
        }

        // Inicializamos el texto de la UI
        if (statusText != null)
        {
            statusText.text = "Esperando llamada de taxi...";
        }
    }

    private void Update()
    {
        if (isTaxiCalled)
        {
            MoveTowardsPlayer();
        }
    }

    // Método para llamar al taxi al hacer clic en el botón
    private void CallTaxi()
    {
        isTaxiCalled = true;
        if (statusText != null)
        {
            statusText.text = "Taxi en camino...";
        }
        Debug.Log("Taxi llamado. El taxi se dirige hacia el jugador.");
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) < 2f)
        {
            isTaxiCalled = false;
            if (statusText != null)
            {
                statusText.text = "Taxi ha llegado. El jugador debe entrar.";
            }
            Debug.Log("Taxi ha llegado. El jugador debe entrar.");
        }
    }
}


