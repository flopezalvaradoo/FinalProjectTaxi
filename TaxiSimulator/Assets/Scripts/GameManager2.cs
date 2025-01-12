using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager2 : MonoBehaviour
{
    public bool HasPlayer = false;
    public List<Transform> spawnPoints; // Lista de puntos de spawn (asignar desde el Inspector)
    public Player player;
    public TaxiUI ui;
    public bool entrar = true;
    public bool finalJuego = false;


    public Vector3 playerPosition;
    public Vector3 finalPosition;
    void Start()
    {
        playerPosition = player.transform.position;
    }
    void Update()
    {
        if (HasPlayer && entrar)
        {
            ui.UpdateTextToDestination();
            entrar = false;
            finalPosition = ui.destinationPosition;

        }
        
        player.cogerTaxi();
        player.dejarTaxi();

        if (finalJuego)
        {
            StartCoroutine(ui.ShowFinal(15));
        }
    }
}

