using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ConvoyData", menuName = "ConvoyData")]
public class ConvoyData : ScriptableObject
{
    [SerializeField] public GameObject[] cars;
    [SerializeField] public float[] distances;
}
