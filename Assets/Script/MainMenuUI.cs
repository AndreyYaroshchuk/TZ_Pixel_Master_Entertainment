using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    private void Start()
    {
        buttonPlay.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
