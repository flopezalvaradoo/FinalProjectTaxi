using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMiniMap : MonoBehaviour
{
    [SerializeField] CarController coche;
    // Update is called once per frame
    void Update()
    {
        Vector3 position = coche.transform.position;
        transform.position = new Vector3(position.x, 950, position.z);
    }
}
