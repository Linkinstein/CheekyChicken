using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI score;

    private void Start()
    {
        string scoreID = "hiscore" + level;
        score.SetText(PlayerPrefs.GetInt(scoreID)+"");
    }
}
