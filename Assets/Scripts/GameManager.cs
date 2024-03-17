using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] carSpawners;
    [SerializeField] public int level = 2;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Link's Scene")
        {
            carSpawners = GameObject.FindGameObjectsWithTag("CarSpawner");

            foreach (GameObject spawners in carSpawners)
            {
                spawners.GetComponent<CarSpawner>().level = level;
            }

            GameObject.FindWithTag("Player").GetComponent<Chicken>().level = level;
        }
    }

}
