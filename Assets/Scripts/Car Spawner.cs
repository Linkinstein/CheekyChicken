using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private ConvoyData[] convoy;
    [SerializeField] public int level = 1;
    [SerializeField] private int x = 1;

    private void Start()
    {
        StartCoroutine(InitialSpawn());
    }

    IEnumerator InitialSpawn()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        SpawnCar();
    }

    public void SpawnCar()
    {
        int j = RNG();
        int length = convoy[j].cars.Length;
        for (int i = 0; i < length; i++)
        {
            Vector3 pos = transform.position;
            pos += new Vector3(-convoy[j].distances[i] * x, 0f, pos.y + 8);
            setupCar( Instantiate(convoy[j].cars[i], pos, this.gameObject.transform.rotation), i+1==length );
        }
    }



    private void setupCar(GameObject car, bool tail)
    {
        Car carS = car.GetComponent<Car>();
        carS.x = x;
        carS.tail = tail;
    }

    private int RNG()
    {
        if ( level == 1 ) return Random.Range(0, 11);
        if (level == 2) return Random.Range(0, 21);
        if (level == 3) return Random.Range(9, 21);
        return 1;
    }
}
