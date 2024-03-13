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
        Vector3 pos = transform.position;
        pos.z = pos.z-1;
        GameObject egg = Instantiate(Eggprefab, pos, this.gameObject.transform.rotation);
        egg.GetComponent<Egg>().number = number;
    }
}
