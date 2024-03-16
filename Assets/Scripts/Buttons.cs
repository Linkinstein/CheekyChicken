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

    private void OnEnable()
    {
        button = GetComponent<Button>();
        if(restart)button.onClick.AddListener(() => Restart());
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Link's Scene");
    }
}
