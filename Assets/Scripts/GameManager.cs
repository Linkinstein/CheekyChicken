using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private GameObject[] carSpawners;
    [SerializeField] public int level = 2;
    [SerializeField] private Sprite[] skins;
    public int skinNo = 0;

    private void Awake()
    {
        if ( instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
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
            chickScript.skinSprite = skins[skinNo];
            chickScript.chickenStun = skins[skinNo+1];
        }
    }

}
