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
        if (restart) button.onClick.AddListener(() => Restart0());
        if (back2menu) button.onClick.AddListener(() => Back2Menu0());
        if (exit) button.onClick.AddListener(() => Exit0());
        if (play) button.onClick.AddListener(() => Play0());
    }

    public void Restart0()
    {
        StartCoroutine(Restart());
    }

    public void Back2Menu0()
    {
        StartCoroutine(Back2Menu());
    }

    public void Exit0()
    {
        StartCoroutine(Exit());
    }

    public void Play0()
    {
        StartCoroutine(Play());
    }

    IEnumerator Restart()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Link's Scene");
    }

    IEnumerator Back2Menu()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator Exit()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
    IEnumerator Play()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        GameObject manager = GameObject.FindWithTag("Manager");
        if (manager != null)
        {
            manager.GetComponent<GameManager>().level = level;
        }
        SceneManager.LoadScene("Link's Scene");
    }

}
