using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject Eggprefab;
    [SerializeField] int number;

    public IEnumerator Spawning()
    {
        yield return new WaitForSeconds(5f);
        GameObject egg = Instantiate(Eggprefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        egg.GetComponent<Egg>().number = number;
    }
}
