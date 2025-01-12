using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaxiUI : MonoBehaviour
{
    [SerializeField] private TMP_Text uiText;
    [SerializeField] private GameObject sphere;
    [SerializeField] private SceneManager_ sceneManager;
    public GameObject uiButton;      

    public Transform destination;
    public GameManager2 gameManager;
    public Player player;

    public GameObject spherePos = null;

    public Vector3 destinationPosition;



    private void Start()
    {
        // Inicialmente ocultamos el texto y el botón
        uiText.gameObject.SetActive(false);
        uiButton.gameObject.SetActive(false);

        // Programar para que aparezcan después de 15 segundos
        StartCoroutine(ShowUIAfterDelay(15));
    }

    public IEnumerator ShowUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Mostrar el texto y el botón
        uiText.gameObject.SetActive(true);
        uiButton.gameObject.SetActive(true);

    }

    public IEnumerator ShowFinal(float delay)
    {
        // Mostrar el texto y el botón
        uiText.text = "Entregaste el pasajero. Final del Juego";
        yield return new WaitForSeconds(delay);
        sceneManager.PonerPrimeraEscena();

    }

    public void OnButtonClickRecoger()
    {

        Vector3 playerPosition = player.transform.position;
        Vector3 spherePosition = new Vector3(playerPosition.x, 930, playerPosition.z);
        uiText.text = "Ve a por el jugador";
        spherePos = Instantiate(sphere, spherePosition, Quaternion.identity);

        uiButton.gameObject.SetActive(false);
    }

    public void UpdateTextToDestination()
    {
        if (destination == null)
        {
            Debug.LogError("No se ha asignado la posición destino.");
            return;
        }
        Destroy(spherePos);
        // Obtener las coordenadas del destino
        destinationPosition = gameManager.player.GetRandomDestination();
        Vector3 spherePosition = new Vector3(destinationPosition.x, 930, destinationPosition.z);
        spherePos = Instantiate(sphere, spherePosition, Quaternion.identity);
        // Cambiar el texto para mostrar el mensaje con la posición destino
        uiText.text = $"Lleva al cliente a la siguente posición";
    }
}

