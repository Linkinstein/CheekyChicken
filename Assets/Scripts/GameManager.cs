using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] carSpawners;
    [SerializeField] public int level = 2;
    [SerializeField] private Sprite[] skins;
    public int skinNo = 1;


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

            Chicken chickScript = GameObject.FindWithTag("Player").GetComponent<Chicken>();
            chickScript.level = level;
            chickScript.skinSprite = skins[skinNo-1];
            chickScript.chickenStun = skins[skinNo];
        }
    }

}
