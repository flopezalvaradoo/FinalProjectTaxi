using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaxiUI : MonoBehaviour
{
    [SerializeField] private TMP_Text uiText;          // Referencia al texto (as�gnalo desde el Inspector)
    public GameObject uiButton;      // Referencia al bot�n (as�gnalo desde el Inspector)
    public Transform player;     // Referencia al jugador (as�gnalo desde el Inspector)

    private void Start()
    {
        // Inicialmente ocultamos el texto y el bot�n
        uiText.gameObject.SetActive(false);
        uiButton.gameObject.SetActive(false);

        // Programar para que aparezcan despu�s de 15 segundos
        StartCoroutine(ShowUIAfterDelay(15));
    }

    private IEnumerator ShowUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Mostrar el texto y el bot�n
        uiText.gameObject.SetActive(true);
        uiButton.gameObject.SetActive(true);

    }

    public void OnButtonClickRecoger()
    {
        if (player == null)
        {
            Debug.LogError("No se ha asignado el jugador.");
            return;
        }

        // Mostrar las coordenadas del jugador en el texto
        Vector3 playerPosition = player.position;
        uiText.text = $"Coordenadas del jugador:\nX: {playerPosition.x:F2}, Y: {playerPosition.y:F2}, Z: {playerPosition.z:F2}";

        // Ocultar el bot�n (ya no ser� necesario)
        uiButton.gameObject.SetActive(false);
    }
}

