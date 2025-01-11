using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> spawnPoints; 

    void Start()
    {

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        Transform childWithPosition = randomSpawnPoint.GetChild(0); 

        Vector3 newPosition = new Vector3(childWithPosition.position.x, transform.position.y, childWithPosition.position.z);

        transform.position = newPosition;
    }
}
