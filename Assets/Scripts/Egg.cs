using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] public int number;

    private void OnDestroy()
    {
        GameObject ads = GameObject.FindWithTag("pickupADS");
        if ( ads != null ) ads.GetComponent<AudioSource>().PlayOneShot(pickupSound);
    }
}
