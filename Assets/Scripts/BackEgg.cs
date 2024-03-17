using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEgg : MonoBehaviour
{
    [SerializeField] AudioSource eggcrack;

    private void OnDisable()
    {
        eggcrack.Play();
    }
}
