using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PedirUI : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text statusText;
    public GameObject button;
    public GameObject buttonTakeTaxi;

    // Método para llamar al taxi al hacer clic en el botón

    void Start()
    {
        buttonTakeTaxi.SetActive(false);
    }

    public void CallTaxi()
    {
        gameManager.isTaxiCalled = true;
        if (statusText != null)
        {
            statusText.text = "Juan esta en camino...";
            button.SetActive(false);
        }
        Debug.Log("Taxi llamado. El taxi se dirige hacia el jugador.");
    }

    public void TaxiArrive()
    {
        statusText.text = "¡El Juan ha llegado!";
        buttonTakeTaxi.SetActive(true);
    }

    public void TakeTaxi()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


