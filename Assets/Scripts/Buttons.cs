using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button button;

    [SerializeField] private bool restart;
    [SerializeField] private bool back2menu;
    [SerializeField] private bool exit;
    [SerializeField] private bool play;
    [SerializeField] private int level = 1;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        if (restart) button.onClick.AddListener(() => Restart());
        if (back2menu) button.onClick.AddListener(() => Back2Menu());
        if (exit) button.onClick.AddListener(() => Exit());
        if (play) button.onClick.AddListener(() => Play());
    }

    public void Restart()
    {
        GameObject.FindWithTag("Manager").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Link's Scene");
    }

    public void Back2Menu()
    {
        GameObject.FindWithTag("Manager").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        GameObject.FindWithTag("Manager").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void Play()
    {
        GameObject.FindWithTag("Manager").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        GameObject manager = GameObject.FindWithTag("Manager");
        if (manager != null)
        {
            manager.GetComponent<GameManager>().level = level;
        }
        SceneManager.LoadScene("Link's Scene");
    }

}
