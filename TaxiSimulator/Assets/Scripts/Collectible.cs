using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] public CarController carController;
    [SerializeField] private bool positive;

    public Collectible(bool positive)
    {
        this.positive = positive;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (positive)
            {
                float newSpeed = carController.GetMotorForce() * 1000;
                carController.SetMotorForce(newSpeed);
            }

            else
            {
                float newSpeed = carController.GetMotorForce() / 100;
                carController.SetMotorForce(newSpeed);
            }
        }
    }
}
