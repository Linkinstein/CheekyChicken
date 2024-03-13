using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    [SerializeField] private GameObject despawnGO;
    [SerializeField] private int level = 1;
    [SerializeField] private int x = 1;

    private void Start()
    {
        StartCoroutine(InitialSpawn());
    }

    IEnumerator InitialSpawn()
    {
        yield return new WaitForSeconds(0.1f);//Random.Range(0f, 5f));
        SpawnCar();
    }

    public void SpawnCar()
    {
        //Random.Range(0, 10);
        int j = RNG();
        switch (j)
        { 
            case 0:
                Vector3 pos = transform.position;
                pos.z = pos.z - 1;
                GameObject egg = Instantiate(cars[0], pos, this.gameObject.transform.rotation);
                egg.GetComponent<Car>().x = x;
                break;

            default: 
                
                break;
        }
    }

    private int RNG()
    {

        return 0;
    }
}
