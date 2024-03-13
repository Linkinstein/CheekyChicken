using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDespawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnGO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (collision.gameObject.GetComponent<Car>().tail) spawnGO.GetComponent<CarSpawner>().SpawnCar();
            Destroy(collision.gameObject);
        }
    }
}
